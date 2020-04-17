using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ComplaintManagmentAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintManagmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]/v1")]
    public class ComplaintController : ControllerBase
    {
        private IComplaint _complaint;
        /// <summary>
        /// Complaint API Dependency.
        ///
        /// </summary>
        /// <param name="complaint"></param>
        public ComplaintController(IComplaint complaint)
        {
            _complaint = complaint;
        }

        /// <summary>
        /// Get All Complaints
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            var result = await _complaint.GetAll();
            return Ok(new {
            status = (int)HttpStatusCode.OK,
            data = result
            });
        }

        [HttpGet]
        [Route("GetBy")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _complaint.GetBy(id);
            return Ok(new
            {
                status = (int)HttpStatusCode.OK,
                data = result
            });
        }

        /// <summary>
        /// Create Complaint 
        /// </summary>
        /// <param name="complaint object"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Models.Complaint obj)
        {
            
            var result = await _complaint.Insert(obj);
            return Ok(new
            {
                status = (int)HttpStatusCode.OK,
                data = result
            });
        }

        /// <summary>
        /// Update Complaints
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Models.Complaint obj)
        {
            var result = await _complaint.Update(obj);
            return Ok(new
            {
                status = (int)HttpStatusCode.OK,
                data = result
            });
        }
    }
}