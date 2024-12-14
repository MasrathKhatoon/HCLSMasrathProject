using HclsPro.DataAccess.IRepositories;
using HclsPro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HclsPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTypesWebAPIController : ControllerBase
    {
        public IAdminTypesRepository admintypesRef;
        public AdminTypesWebAPIController(IAdminTypesRepository _admintypesRef)
        {
            admintypesRef = _admintypesRef;
        }
        //Web API//Insertion of data
        [HttpPost]
        [Route("InsertAdminTypes")]
        public async Task<IActionResult> InsertAdminTypes(AdminTypes Admt)
        {
            try
            {
                var count = await admintypesRef.InsertAdminTypes(Admt);
                if (count > 0)
                {
                    return Ok(count + "Record inserted...!");
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
        //Web api // Read all data
        [HttpGet]
        [Route("AllAdminTypes")]
        public async Task<IActionResult> AllAdminTypes()
        {
            try
            {
                var Admintypes = await admintypesRef.AllAdminTypes();
                if (Admintypes.Count > 0)
                {
                    return Ok(Admintypes);
                }
                else
                {
                    return NotFound(" records not found ");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }
        //Web API //Reading PK data
        [HttpGet]
        [Route("AdminTypesByAdminTypeID")]
        public async Task<IActionResult> AdminTypesByAdminTypeID(int AdminTypeId)
        {
            try
            {
                var AdminTypesId = await admintypesRef.GetAdminTypesByAdminTypeId(AdminTypeId);
                if (AdminTypesId != null)
                {
                    return Ok(AdminTypesId);
                }
                else
                {
                    return NotFound("Records are not available...!");
                }
            }
            catch (Exception ex)
            { 
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }
        //Web API // Updating data
        [HttpPut]
        [Route("UpdateAdminType")]
        public async Task<IActionResult> UpdateAdminType(AdminTypes Admt)
        {
            try
            {
                var count = await admintypesRef.UpdateAdminTypes(Admt);
                if (count > 0)
                {
                    return Ok(count + "Record Updated...!");
                }
                else
                {
                    return NotFound("Records are not Updated...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }
        //Web API // Delete AdminTypeIDs
        [HttpDelete]
        [Route("DeleteAdminTypes")]
        public async Task<IActionResult> DeleteAdminTypes(int AdminTypeId)
        {
            try 
            {
                var deleteAdminType = await admintypesRef.DeleteAdminTypes(AdminTypeId);
                if(deleteAdminType > 0)
                {
                    return Ok(deleteAdminType + "Record deleted...!");
                }
                else
                {
                    return NotFound("No Record Deleted...!");
                }  
            }
            catch(Exception ex) 
            {
                return BadRequest("Sorry for inconvenience...!\nWe will solve this issue soon...!\n" + ex.Message);
            }

        }

    }
}
