using HclsPro.DataAccess.IRepositories;
using HclsPro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HclsPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminWebAPIController : ControllerBase
    {
        public IAdminRepository adminRef;

        public AdminWebAPIController(IAdminRepository _adminRef)
        {
            adminRef = _adminRef;
        }
        //Web api method //insert admin data
        [HttpPost]
        [Route("InsertAdmin")]
        public async Task<IActionResult> InsertAdmin(Admin Adm)
        {
            try
            {
                var count = await adminRef.InsertAdmin(Adm);
                if (count > 0)
                {
                    return Ok(count + "record inserted...!");
                }
                else
                {
                    return BadRequest("data not inserted...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }
        //Web api method //Read admin data
        [HttpGet]
        [Route("AllAdmins")]
        public async Task<IActionResult> AllAdmins()
        {
            try
            {
                var admins = await adminRef.GetAllAdmin();
                if (admins.Count > 0)
                {
                    return Ok(admins);
                }
                else
                {
                    return NotFound("There is no data available...!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }
        [HttpGet]
        [Route("AdminByAdminId")]
        public async Task<IActionResult> AdminByAdminId(int AdminId)
        {
            try
            {
                var Admin = await adminRef.GetAdminByAdminId(AdminId);
                if (Admin != null)
                {
                    return Ok(Admin);
                }
                else
                {
                    return NotFound("Record is not available...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }
        [HttpGet]
        [Route("AdminByEmailPassword")]
        public async Task<IActionResult> AdminByEmailPassword(string Email, string Password)
        {
            try 
            {
                var Admin = await adminRef.GetAdminByEmailAndPassword(Email, Password);
                if(Admin != null)
                {
                    return Ok(Admin);
                }
                else
                {
                    return BadRequest("Record is not available...!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        } 
        //Web API //Updating data
        [HttpPut]
        [Route("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin(Admin Adm)
        {
            try
            {
                var count = await adminRef.UpdateAdmin(Adm);
                if (count > 0)
                {
                    return Ok(count + "Record updated...!");
                }
                else
                {
                    return BadRequest("Data not Updated...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }
        //Web API //Delete records
        [HttpDelete]
        [Route("DeleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(int AdminId)
        {
            try
            {
                var Admindelete = await adminRef.DeleteAdmin(AdminId);
                if (Admindelete > 0)
                {
                    return Ok(Admindelete + "Record deleted...!");
                }
                else
                {
                    return BadRequest("No Record deleted...!");                  
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }
    }
}
