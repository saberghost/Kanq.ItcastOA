﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ICalculateService")]
public interface ICalculateService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculateService/Add", ReplyAction="http://tempuri.org/ICalculateService/AddResponse")]
    int Add(int a, int b);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculateService/Add", ReplyAction="http://tempuri.org/ICalculateService/AddResponse")]
    System.Threading.Tasks.Task<int> AddAsync(int a, int b);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ICalculateServiceChannel : ICalculateService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class CalculateServiceClient : System.ServiceModel.ClientBase<ICalculateService>, ICalculateService
{
    
    public CalculateServiceClient()
    {
    }
    
    public CalculateServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public CalculateServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CalculateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CalculateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int Add(int a, int b)
    {
        return base.Channel.Add(a, b);
    }
    
    public System.Threading.Tasks.Task<int> AddAsync(int a, int b)
    {
        return base.Channel.AddAsync(a, b);
    }
}
