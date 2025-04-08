using Microsoft.AspNetCore.Mvc;
using reimbursmentServicesApi.Models;
using reimbursmentServicesApi.Services;

namespace reimbursmentServicesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReimbursementController : ControllerBase
    {
        private readonly MongoService _mongoService;
        private readonly IWebHostEnvironment _env;

        public ReimbursementController(MongoService mongoService, IWebHostEnvironment env)
        {
            _mongoService = mongoService;
            _env = env;
        }

        [HttpPost]
        [Consumes("multipart/form-data")] 
        public async Task<IActionResult> Post([FromForm] DateTime date, [FromForm] decimal amount, [FromForm] string description, [FromForm] IFormFile receipt)
        {
            if (receipt == null || receipt.Length == 0)
                return BadRequest("Receipt file is required.");

            var uploadsFolder = Path.Combine(_env.ContentRootPath, "Uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, receipt.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await receipt.CopyToAsync(stream);
            }

            var reimbursement = new Reimbursement
            {
                Date = date,
                Amount = amount,
                Description = description,
                ReceiptFileName = receipt.FileName,
                ReceiptFilePath = filePath
            };

            await _mongoService.CreateAsync(reimbursement);

            return Ok(new { message = "Reimbursement submitted successfully!" });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reimbursements = await _mongoService.GetAllAsync();
            return Ok(reimbursements);
        }
    }
}
