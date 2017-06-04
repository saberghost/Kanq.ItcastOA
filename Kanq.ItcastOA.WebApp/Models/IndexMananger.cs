using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace Kanq.ItcastOA.WebApp.Models
{
    public sealed class IndexMananger
    {
        #region 创建单列
        private static readonly IndexMananger indexMananger = new IndexMananger();

        private IndexMananger() { }

        public static IndexMananger GetInstance()
        {
            return indexMananger;
        } 
        #endregion

        public Queue<ViewModelContent> queue = new Queue<ViewModelContent>();

        /// <summary>
        /// 向队列中添加数据
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Title"></param>
        /// <param name="ContentDescription"></param>
        public void AddQueue(int Id, string Title, string ContentDescription)
        {
            ViewModelContent viewModel = new ViewModelContent()
            {
                Id = Id,
                Title = Title,
                ContentDescription = ContentDescription,
                LuceneEnum = EnumType.LuceneEnum.Add
            };
            queue.Enqueue(viewModel);
        }

        public void DeleteQueue(int Id)
        {
            ViewModelContent viewModel = new ViewModelContent()
            {
                Id = Id,
                LuceneEnum = EnumType.LuceneEnum.Delete
            };
            queue.Enqueue(viewModel);
        }

        /// <summary>
        /// 开启一个线程
        /// </summary>
        public void StartThread()
        {
            Thread thread = new Thread(WriteInexContent);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 检查队列中是否有数据，有数据则获取
        /// </summary>
        private void WriteInexContent()
        {
            while (true)
            {
                if (queue.Count > 0)
                {
                    CreateIndexContent();
                }
                else
                {
                    Thread.Sleep(3000);
                }
            }
        }

        /// <summary>
        /// 创建索引库
        /// </summary>
        private void CreateIndexContent()
        {
            string indexPath = @"D:\WebSites\lucenedir";//注意和磁盘上文件夹的大小写一致，否则会报错。将创建的分词内容放在该目录下。
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());//指定索引文件(打开索引目录) FS指的是就是FileSystem
            bool isUpdate = IndexReader.IndexExists(directory);//IndexReader:对索引进行读取的类。该语句的作用:判断索引库文件夹是否存在以及索引特征文件是否存在。
            if (isUpdate)
            {
                //同时只能有一段代码对索引库进行写操作。当使用IndexWriter打开directory时会自动对索引库文件上锁。
                //如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁（提示一下:如果我现在正在写着已经加锁了，但是还没有写完，这时候又来一个请求，那么不就解锁了吗？这个问题后面会解决）
                if (IndexWriter.IsLocked(directory))
                {
                    IndexWriter.Unlock(directory);
                }
            }
            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);//向索引库中写索引。这时在这里加锁。
            while (queue.Count > 0)
            {
                ViewModelContent viewModel = queue.Dequeue();
                writer.DeleteDocuments(new Term("Id", viewModel.Id.ToString()));
                if (viewModel.LuceneEnum == EnumType.LuceneEnum.Delete)
                {
                    continue;
                }
                Document document = new Document();//表示一篇文档。
                //Field.Store.YES:表示是否存储原值。只有当Field.Store.YES在后面才能用doc.Get("number")取出值来.Field.Index. NOT_ANALYZED:不进行分词保存
                document.Add(new Field("Id", viewModel.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));

                //Field.Index. ANALYZED:进行分词保存:也就是要进行全文的字段要设置分词 保存（因为要进行模糊查询）

                //Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS:不仅保存分词还保存分词的距离。
                document.Add(new Field("Title", viewModel.Title, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
                document.Add(new Field("ContentDescription", viewModel.ContentDescription, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
                writer.AddDocument(document);
            }
            writer.Dispose();//会自动解锁。
            directory.Dispose();//不要忘了Close，否则索引结果搜不到
        }
    }
}