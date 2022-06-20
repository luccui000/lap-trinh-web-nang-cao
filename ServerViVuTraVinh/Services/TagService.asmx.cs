using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ServerViVuTraVinh.Helpers;

namespace ServerViVuTraVinh.Services
{ 
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)] 
    public class TagService : BaseService
    { 
        [WebMethod]
        public JsonResponse<List<Tag>> index()
        {
            return new JsonResponse<List<Tag>>()
            {
                Error = false,
                Message = "Lấy dữ liệu thành công",
                Data = db.Tags.ToList(),
                StatusCode = 200
            };
        }
        [WebMethod]
        public JsonResponse<string> store(string TenTag, string MoTa, string NgayTao = null, string TrangThai = "1")
        {
            try
            {
                Tag t = new Tag();
                t.TenTag = TenTag;
                t.MoTa = MoTa;
                if (!string.IsNullOrEmpty(NgayTao))
                    t.NgayTao = DateTime.Parse(NgayTao);
                else
                    t.NgayTao = DateTime.Today;
                t.TrangThai = Int32.Parse(TrangThai);

                db.Tags.InsertOnSubmit(t);
                db.SubmitChanges();
                return new JsonResponse<string>()
                {
                    Error = false,
                    Message = "Thêm hashtag thành công",
                    Data = "",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new JsonResponse<string>()
                {
                    Error = true,
                    Message = ex.Message,
                    Data = "",
                    StatusCode = 200
                };
            }
        }
        [WebMethod]
        public JsonResponse<bool> update(int Id, string TenTag, string MoTa, string NgayTao = null, string TrangThai = "1")
        {
            try
            {
                Tag t = db.Tags.Single(d => d.Id == Id);
                t.TenTag = TenTag;
                t.MoTa = MoTa;
                if (!string.IsNullOrEmpty(NgayTao))
                    t.NgayTao = DateTime.Parse(NgayTao);
                
                t.TrangThai = Int32.Parse(TrangThai);

                db.SubmitChanges();
                return new JsonResponse<bool>()
                {
                    Error = false,
                    Message = "Cập nhật hashtag thành công",
                    Data = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new JsonResponse<bool>()
                {
                    Error = true,
                    Message = ex.Message,
                    Data = false,
                    StatusCode = 200
                };
            }
        }
        [WebMethod]
        public JsonResponse<bool> delete(int Id)
        {
            try
            {
                Tag t = db.Tags.FirstOrDefault(d => d.Id == Id);
                db.Tags.DeleteOnSubmit(t);
                db.SubmitChanges();
                return new JsonResponse<bool>()
                {
                    Error = false,
                    Message = "Xoá hashtag thành công",
                    Data = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new JsonResponse<bool>()
                {
                    Error = true,
                    Message = ex.Message,
                    Data = false,
                    StatusCode = 200
                };
            }
        }
    }
}
