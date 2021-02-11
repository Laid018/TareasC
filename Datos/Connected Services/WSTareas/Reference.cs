﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos.WSTareas {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WSTareas.WSTareasSoap")]
    public interface WSTareasSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListarTareas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ListarTareas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListarTareas", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ListarTareasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarTareas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet BuscarTareas(string titulo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarTareas", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> BuscarTareasAsync(string titulo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarTareasCompletadas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet BuscarTareasCompletadas(string titulo, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarTareasCompletadas", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> BuscarTareasCompletadasAsync(string titulo, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarTareasPendientes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet BuscarTareasPendientes(string titulo, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarTareasPendientes", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> BuscarTareasPendientesAsync(string titulo, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarTareasSinComenzar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet BuscarTareasSinComenzar(string titulo, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarTareasSinComenzar", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> BuscarTareasSinComenzarAsync(string titulo, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MostrarTareasCompletadas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet MostrarTareasCompletadas(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MostrarTareasCompletadas", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> MostrarTareasCompletadasAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MostrarTareasPendientes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet MostrarTareasPendientes(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MostrarTareasPendientes", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> MostrarTareasPendientesAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MostrarTareasSinComenzar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet MostrarTareasSinComenzar(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MostrarTareasSinComenzar", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> MostrarTareasSinComenzarAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSTareasSoapChannel : Datos.WSTareas.WSTareasSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSTareasSoapClient : System.ServiceModel.ClientBase<Datos.WSTareas.WSTareasSoap>, Datos.WSTareas.WSTareasSoap {
        
        public WSTareasSoapClient() {
        }
        
        public WSTareasSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSTareasSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSTareasSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSTareasSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet ListarTareas() {
            return base.Channel.ListarTareas();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ListarTareasAsync() {
            return base.Channel.ListarTareasAsync();
        }
        
        public System.Data.DataSet BuscarTareas(string titulo) {
            return base.Channel.BuscarTareas(titulo);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> BuscarTareasAsync(string titulo) {
            return base.Channel.BuscarTareasAsync(titulo);
        }
        
        public System.Data.DataSet BuscarTareasCompletadas(string titulo, int id) {
            return base.Channel.BuscarTareasCompletadas(titulo, id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> BuscarTareasCompletadasAsync(string titulo, int id) {
            return base.Channel.BuscarTareasCompletadasAsync(titulo, id);
        }
        
        public System.Data.DataSet BuscarTareasPendientes(string titulo, int id) {
            return base.Channel.BuscarTareasPendientes(titulo, id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> BuscarTareasPendientesAsync(string titulo, int id) {
            return base.Channel.BuscarTareasPendientesAsync(titulo, id);
        }
        
        public System.Data.DataSet BuscarTareasSinComenzar(string titulo, int id) {
            return base.Channel.BuscarTareasSinComenzar(titulo, id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> BuscarTareasSinComenzarAsync(string titulo, int id) {
            return base.Channel.BuscarTareasSinComenzarAsync(titulo, id);
        }
        
        public System.Data.DataSet MostrarTareasCompletadas(int id) {
            return base.Channel.MostrarTareasCompletadas(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> MostrarTareasCompletadasAsync(int id) {
            return base.Channel.MostrarTareasCompletadasAsync(id);
        }
        
        public System.Data.DataSet MostrarTareasPendientes(int id) {
            return base.Channel.MostrarTareasPendientes(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> MostrarTareasPendientesAsync(int id) {
            return base.Channel.MostrarTareasPendientesAsync(id);
        }
        
        public System.Data.DataSet MostrarTareasSinComenzar(int id) {
            return base.Channel.MostrarTareasSinComenzar(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> MostrarTareasSinComenzarAsync(int id) {
            return base.Channel.MostrarTareasSinComenzarAsync(id);
        }
    }
}