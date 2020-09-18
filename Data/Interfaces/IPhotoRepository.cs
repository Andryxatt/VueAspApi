using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;

namespace VueAsp.Data.Interfaces
{
   public interface IPhotoRepository : IRepositoryBase<Photo>
    {
		IEnumerable<Photo> GetPhotosByProductId(Guid productId);
		Photo GetPhotoById(Guid photoId);
		Photo GetPhotoWithDetails(Guid photoId);
		void CreatePhoto(Photo photo);
		void UpdatePhoto(Photo photo);
		void DeletePhoto(Photo photo);
		void DeletePhotoRange(IEnumerable<Photo> photo);
	}
}
