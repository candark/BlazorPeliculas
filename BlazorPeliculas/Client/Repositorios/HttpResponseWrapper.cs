namespace BlazorPeliculas.Client.Repositorios
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public  bool Error { get; set; }
        public T? Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> ObtenerMensajeError()
        {
            if (!Error)
            {
                return null;
            }
            else
            {
                var codigoEstatus = HttpResponseMessage.StatusCode;

                if (codigoEstatus == System.Net.HttpStatusCode.NotFound) 
                {
                    return "Recurso no encontrado";
                } else if (codigoEstatus == System.Net.HttpStatusCode.BadRequest)
                {
                    return await HttpResponseMessage.Content.ReadAsStringAsync();
                } else if (codigoEstatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return "Tienes que logearte para hacer esto";
                } else if (codigoEstatus == System.Net.HttpStatusCode.Forbidden)
                {
                    return "No tienes permiso para hacer esto";
                } else
                {
                    return "Ha ocurrido un error inesperado";
                }
            }
        }
    }
}
