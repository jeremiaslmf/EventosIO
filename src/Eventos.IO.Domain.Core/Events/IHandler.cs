namespace Eventos.IO.Domain.Core.Events
{
    /// <summary>
    /// IHandler<in T>: 'in' -> corresponde a um tipo "CONTRAVARIANTE"
    /// A contravariância permite que você use um tipo menos derivado do que 
    /// aquele especificado pelo parâmetro genérico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
