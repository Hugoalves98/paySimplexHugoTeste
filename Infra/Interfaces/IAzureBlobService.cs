using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IAzureBlobService
    {
        public string FileUploadBase64(string base64Image);
    }
}
