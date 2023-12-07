namespace EvoSystems.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;

        public static implicit operator ServiceResponse<T>(ServiceResponse<Departament> v)
        {
            throw new NotImplementedException();
        }
    }
}
