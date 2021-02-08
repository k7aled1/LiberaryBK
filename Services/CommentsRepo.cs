using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiberaryBK.Data;
using LiberaryBK.Models;
using Microsoft.EntityFrameworkCore;

namespace LiberaryBK.Services
{
    public interface IComments
    {
        IEnumerable<Comments> GetAllComnt();
        IEnumerable<Comments> GetComntsByBookId(int Id);
        void AddComnt(Comments Comnt);
        void DeleteComnt(int Id);
/*        async Task EditComnt(int Id,string comntTxt,string comntPic);
*/    }
    public class CommentsRepo:IComments
    {
        private readonly ApplicationDbContext db;

        public CommentsRepo(ApplicationDbContext db)
        {
            this.db = db;
            
        }

        public void AddComnt(Comments Comnt)
        {
            /*Comnt.UserF4= "aa4e1481-b20d-41f5-b778-e5cc8b6fe20f";*/
            db.Comments.Add(Comnt);
            db.SaveChanges();
        }

        public void DeleteComnt(int Id)
        {
           
            Comments comn = db.Comments.FirstOrDefault(c => c.ComntId == Id);
            db.Comments.Remove(comn);
            db.SaveChanges();
        }

        /*public async Task  EditComnt(int? Id*//*, string comntTxt, string comntPic*//*)
        {
            *//*if (Id == null)
            {
                return NotFound();
            }*//*

            Comments comn =await db.Comments.FindAsync(Id);

            comn.ComntText = comntTxt;
            comn.ComntPic = comntPic;
            db.SaveChanges();
        }*/

        public IEnumerable<Comments> GetAllComnt()
        {
            var com = db.Comments.Include(c => c.BookF3Navigation).Include(c => c.Userc);
            return com.ToList();
        }

        public IEnumerable<Comments> GetComntsByBookId(int Id)
        {
            return (db.Comments.Where(c => c.BookF3Navigation.BookId == Id).ToList());
        }
    }
}
