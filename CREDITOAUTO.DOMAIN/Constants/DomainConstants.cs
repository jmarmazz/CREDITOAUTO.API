
namespace CREDITOAUTO.DOMAIN.Constants
{
    public static class DomainConstants
    {
        public const string ERRORCLIENTE_SOLICITUDINVALIDA = "C01";
        public const string ERROR_DATO_EXISTENTE = "C02";
        public const string ERRORCLIENTE_SOLICITUDEXISTENTE = "C03";
        public const string ERRORCLIENTE_VEHICULORESERVADO = "C04";
        public const string ERRORCLIENTE_ASIGNADOPATIO = "C05";
        public const string ERRORCLIENTE_CREDITOACTIVO = "C06";
        public const string ERRORCLIENTE_PLACAEXISTENTE = "C07";
        public const string ERRORCLIENTE_PATIOEXISTENTE= "C08";

        public const string PARAMETRO_RUTA_CSVCREDITOCLIENTE = "RUTA_CSVCREDITOCLIENTE";
        public const string PARAMETRO_RUTA_CSVCREDITOMARCA = "RUTA_CSVCREDITOMARCA";
        public const string PARAMETRO_RUTA_CSVCREDITOEJECUTIVO = "RUTA_CSVCREDITOEJECUTIVO";

        public static short ObtenerHttpStatusCode(string CodigoError)
        {
            if (string.IsNullOrEmpty(CodigoError))
            {
                return 200;
            }

            switch (CodigoError)
            {
                case ERRORCLIENTE_SOLICITUDINVALIDA:
                case ERROR_DATO_EXISTENTE: 
                case ERRORCLIENTE_SOLICITUDEXISTENTE:
                case ERRORCLIENTE_VEHICULORESERVADO:
                case ERRORCLIENTE_ASIGNADOPATIO:
                case ERRORCLIENTE_CREDITOACTIVO:
                case ERRORCLIENTE_PLACAEXISTENTE:
                    return 400;
                default:
                    return 500;
            }
        }

    }
    public enum EstadoSolicitud
    {
        Registrada = 1,
        Despachada = 2,
        Cancelada = 3 
    }
}
