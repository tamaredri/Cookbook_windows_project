using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Imagga
{
    public interface IImaggaService
    {
        /// <summary>
        /// Finding similarities between 2 images.
        /// Provide web url's for both images.
        /// If a local image is used - first upload the image to the server using 'UploadImageToServer' 
        /// and use the upload_id as the image's url
        /// </summary>
        /// <param name="url1"></param>
        /// <param name="url2"></param>
        /// <returns>True - if the images are close. False - if the images are too distante</returns>
        public bool IsSimilarImages(string url1, string url2);

        /// <summary>
        /// Upload a image to the server for further use with any service of Imagga. 
        /// </summary>
        /// <param name="ImageUrl">The location of the image on your device</param>
        /// <returns>upload id identifying the image on the server</returns>
        public string UploadImageToServer(string ImageUrl);

        /// <summary>
        /// use the upload id to delete any image you uploaded to the server.
        /// </summary>
        /// <param name="UploadID"></param>
        public void DeleteImageFromServer(string UploadID);
    }
}
