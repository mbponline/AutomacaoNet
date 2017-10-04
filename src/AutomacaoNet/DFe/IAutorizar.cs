namespace AutomacaoNet.DFe
{
    public interface IAutorizar<Entity>
    {
        IRespostaAutorizar Enviar(Entity entity);
    }

}