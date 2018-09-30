using Infrastructure.DAL.Connection;

namespace Infrastructure.ServiceLayer.UnitOfWork
{
    /// <summary>
    /// Creates a new unit of work.
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IConnectionFactory _connectionFactory;

        public UnitOfWorkFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_connectionFactory.Create());
        }
    }
}
