using KDS.Infraestructure.CrossCutting.Enums;

namespace KDS.Infraestructure.CrossCutting.Entities
{
    public class ValidationResult
    {
        public ValidationResult()
        {
        }

        public ValidationResult(TipoResultado typeResult, string message = null, object data = null, int? width = null)
        {
            this.TypeResult = typeResult;
            
            this.Data = Data;
            
            if (string.IsNullOrWhiteSpace(message))
            {
                if (TypeResult == TipoResultado.Success)
                    message = Resources.Messages.Success;
                else if (TypeResult == TipoResultado.Error)
                    message = Resources.Messages.Error;
            }
            this.Message = message;

            if (width == null)
            {
                if (TypeResult == TipoResultado.Success)
                    width = 350;
                else if (TypeResult == TipoResultado.Error)
                    width = 475;
                else
                    width = 0;
            }
            this.Width = string.Format("{0}px", width);
        }

        public TipoResultado TypeResult { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
        
        public string Width { get; set; }               

        public bool Succeeded
        {
            get
            {
                if (TypeResult == TipoResultado.Success)
                    return true;
                else
                    return false;
            }
        }

        public string Type
        {
            get
            {
                if (TypeResult == TipoResultado.Success)
                    return "success";
                else if (TypeResult == TipoResultado.Error)
                    return "error";
                else if (TypeResult == TipoResultado.Information)
                    return "info";
                else
                    return null;
            }
        }

        public string Title
        {
            get
            {
                if (TypeResult == TipoResultado.Success)
                    return "Operación exitosa";
                else if (TypeResult == TipoResultado.Error)
                    return "Operación fallida";
                else if (TypeResult == TipoResultado.Information)
                    return "Información";
                else
                    return null;
            }
        }

        public string Icon
        {
            get
            {
                if (TypeResult == TipoResultado.Success)
                    return "glyphicon glyphicon-ok-sign";
                else if (TypeResult == TipoResultado.Error)
                    return "glyphicon glyphicon-warning-sign";
                else if (TypeResult == TipoResultado.Information)
                    return "glyphicon glyphicon-info-sign";
                else
                    return null;
            }
        }
    }
}