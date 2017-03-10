using System;
using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IBll
{
    internal interface IUserSubAccountBll
    {
        void Add(UserSubAccount subAccount, Action<UserSubAccountOptState> addResponse);

        void Delete(UserSubAccount subAccount, Action<UserSubAccountOptState> deleteResponse);

        void Update(UserSubAccount subAccount, Action<UserSubAccountOptState> updateResponse);

        void GetList(Action<DataResponse<
            UserSubAccountOptState, IList<UserSubAccount>>> listResponse);

        void GetPageList(PageListQueryInfo<UserSubAccountPageListQuery> info, Action<DataResponse<
            UserSubAccountOptState, Page<UserSubAccountPageListVM>>> getPageListResponse);

        void AddResponse(UserSubAccountOptState state);

        void DeleteResponse(UserSubAccountOptState state);

        void UpdateResponse(UserSubAccountOptState state);

        void GetListResponse(DataResponse<
            UserSubAccountOptState, IList<UserSubAccount>> listResponse);

        void GetPageListResponse(DataResponse<
            UserSubAccountOptState, Page<UserSubAccountDetails>> pageListResponse);
    }
}