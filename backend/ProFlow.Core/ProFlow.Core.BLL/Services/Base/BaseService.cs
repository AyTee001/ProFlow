using AutoMapper;
using ProFlow.Core.DAL.MongoDbData;
using ProFlow.Core.DAL.SqlServerData.Context;

namespace ProFlow.Core.BLL.Services.Base
{
    public class BaseService
    {
        private protected readonly ProFlowMongoDbContext _mongoContext;
        private protected readonly ProFlowSqlContext _sqlcontext;
        private protected readonly IMapper _mapper;

        protected BaseService(ProFlowMongoDbContext mongoContext, ProFlowSqlContext sqlContext, IMapper mapper)
        {
            _mongoContext = mongoContext;
            _sqlcontext = sqlContext;
            _mapper = mapper;
        }
    }
}
