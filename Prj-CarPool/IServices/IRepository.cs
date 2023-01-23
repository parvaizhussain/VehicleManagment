using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

using Domain.ViewModels;

namespace Prj_CarPool.IServices
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsysnc(string url, int id, string token);

        Task<T> GetAsysnc_string(string url, string id, string token);
        Task<IEnumerable<T>> GetAsysnc_strings(string url, int Bid, string token);
        Task<T> GetAsysnc_stringClass(string url, int id, int Bid,int CID, string token);
        Task<T> GetAsysnc_stringClassSess(string url, int id, int Bid, int CID, int SID, string token);
        Task<string> GetLastConcessionCode(string url,string token);
        Task<string> GetRollNo(string url,string id,string token);
        Task<string> CreateAsyncReturnID(string url, T obj, string token, string table, string colname);
        Task<IEnumerable<T>> GetAllAsyncList(string url, int Id, string token);
        Task<IEnumerable<T>> GetAllAsyncListbyString(string url, string Id, string token);
        Task<IEnumerable<T>> GetAllAsync(string url, string token);
        Task<bool> CreateAsync(string url, T obj, string token);
        Task<string> CreateAsyncJson(string url, T obj, string token); 
        Task<string> CreateAsync_list(string url, T obj, string token);
        Task<bool> CreateAsynclist(string url, List<T> obj, string token);
        //Task<bool> CreateAsync_list_ClassSubjects(string url, ClassSubject obj, string token);
      //  Task<bool> UpdateAsync_list_ClassSubjects(string url, ClassSubject obj, string token);
        Task<bool> UpdateAsync(string url, T obj, string token);
      //  Task<bool> UpdateAsyncACStd(string url, UpdateStdAdvanceChallanCommand obj, string token);
        Task<bool> UpdateAsync_Put(string url, T obj, string token);
        Task<string> UpdateAsync_list(string url, T obj, string token);
        Task<bool> UpdateIsDelete_Put(string url, T obj, string token);
       // Task<IEnumerable<T>> GetAllAsyncStdReg(string url, string token, GetStudentRegistrationListQuery obj);
        Task<bool> DeleteAsync(string url, int id, string token);

    }
}
