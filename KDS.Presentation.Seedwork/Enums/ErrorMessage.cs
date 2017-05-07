namespace KDS.Presentation.Seedwork.Enums
{
    public class ErrorMessage
    {
        public class DataAnnotation
        {
            public const string CampoRequerido = "El campo es obligatorio.";
            public const string LongitudMinima = "Debe superar los {1} caracteres.";
            public const string LongitudMaxima = "No debe superar los {1} caracteres.";
            public const string LongitudFija = "Debe ingresar {1} caracteres.";
            public const string SoloNumeros = "El campo acepta solo números enteros.";
        }        
    }
}
