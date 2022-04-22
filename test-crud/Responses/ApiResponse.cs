using test_crud.core.CustomEntities;

namespace test_crud.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Metadata Metadata { get; set; }
    }
}
