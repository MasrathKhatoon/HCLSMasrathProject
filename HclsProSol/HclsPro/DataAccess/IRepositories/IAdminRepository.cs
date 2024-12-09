using HclsPro.Models;

namespace HclsPro.DataAccess.IRepositories
{
    public interface IAdminRepository
    {
        Task<int> InsertAdmin(Admin Adm);//Insert
        //READING 
        Task<List<Admin>> GetAllAdmin();//All data
        Task<Admin> GetAdminByAdminId(int AdminId);//PK data using Find
        Task<List<Admin>> GetAdminByActiveStatus(bool ActiveStatus);//Single data using Where
        Task<Admin> GetAdminByEmailAndPassword(string Email, string Password);//Multiple using Where
        Task<int> UpdateAdmin(Admin Adm);//Update data
        Task<int> DeleteAdmin(int AdminId);//Delete perticular data
        Task<int> DeleteAllAdmin();//Delete data
    }
}
