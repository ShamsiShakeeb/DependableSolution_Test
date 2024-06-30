using DAL.Ado;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class PurchaseOrderContext : AdoProperties, IPurchaseOrderContext
    {
        private readonly IConfiguration _configuration;
        public PurchaseOrderContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override string ConnectionString()
        {
            return _configuration.GetConnectionString("DevConnection");
        }
    }
}
