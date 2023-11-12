namespace ProductMiniApi.Repository.Abastract
{
    public interface ITestFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }
}
