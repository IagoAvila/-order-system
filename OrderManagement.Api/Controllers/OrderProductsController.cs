using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Api.Data;
using OrderManagement.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Rota para obter todos os OrderProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderProduct>>> GetOrderProducts()
        {
            return await _context.OrderProducts.ToListAsync();
        }

        // Rota para obter um OrderProduct específico usando GUID para OrderId e ProductId
        [HttpGet("{orderId:guid}/{productId:guid}")]
        public async Task<ActionResult<OrderProduct>> GetOrderProduct(Guid orderId, Guid productId)
        {
            var orderProduct = await _context.OrderProducts
                .FirstOrDefaultAsync(op => op.OrderId == orderId && op.ProductId == productId);

            if (orderProduct == null)
                return NotFound();

            return orderProduct;
        }

        // Rota para criar um novo OrderProduct
        [HttpPost]
        public async Task<ActionResult<OrderProduct>> PostOrderProduct(OrderProduct orderProduct)
        {
            // Adiciona o OrderProduct no banco de dados
            _context.OrderProducts.Add(orderProduct);
            await _context.SaveChangesAsync();

            // Retorna a resposta de criação com o local do novo recurso criado
            return CreatedAtAction(nameof(GetOrderProduct), new { orderId = orderProduct.OrderId, productId = orderProduct.ProductId }, orderProduct);
        }
    }
}
