using Microsoft.AspNetCore.Components.Forms;

namespace LaliWebShop.Server.Service.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        Task<bool> DeleteFile(string file);
    }
}
