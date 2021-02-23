using System.Collections.Specialized;

namespace Shotr.Core.Uploader
{
    public interface IImageUploader
    {
        /// <summary>
        /// The title of your uploader (also the title that shows in Shotr).
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// To use your own custom upload method, set this to true and override the UploadImage function.
        /// </summary>
        public bool UseUploadMethod { get; }

        /// <summary>
        /// The file value upload. Only used if UseUploadMethod is set to false.        
        /// </summary>
        public string FileValueName { get; }

        /// <summary>
        /// The URL to the uploader script. Only used if UseUploadMethod is set to false.
        /// </summary>
        public string UploaderUrl { get; }

        /// <summary>
        /// Values to submit when uploading. Only used if UseUploadMethod is set to false.
        /// </summary>
        public NameValueCollection UploadValues { get; }

        /// <summary>
        /// Values to add to headers when uploading. Only used if UseUploadMethod is set to false.
        /// </summary>
        public NameValueCollection HeaderValues { get; }

        /// <summary>
        /// Supports non-direct URLs (for instance, http://imgur.com/customimage)
        /// </summary>
        public bool SupportsPages { get; }

        /// <summary>
        /// The non-direct URL starting.
        /// </summary>
        public string PageUrl { get; }

        /// <summary>
        /// Values to submit when posting to the website to delete an image.
        /// </summary>
        public NameValueCollection DeletionValues { get; }

        /// <summary>
        /// Your custom image uploader handler. To use this, set UseUploadMethod to true.
        /// </summary>
        /// <param name="filedata">A memorystream containing the data to the image.</param>
        /// <param name="filename">The filename of the image being uploaded.</param>
        /// <returns>new UploadResult Instance. If the upload fails, UploadResult.Error should be set to true.</returns>
        public UploadResult UploadImage(FileShell fileShell);
    }
}