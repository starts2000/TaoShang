using System;
using System.Linq;
using System.Collections.Generic;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;
using Starts2000.TaoBao.Views.Utils;

namespace Starts2000.TaoBao.Core.Bll
{
    class UserSubAccountBll : IUserSubAccountBll
    {
        Action<UserSubAccountOptState> _addResponse;
        Action<UserSubAccountOptState> _deleteResponse;
        Action<UserSubAccountOptState> _updateResponse;
        Action<DataResponse<
            UserSubAccountOptState, IList<UserSubAccount>>> _getListResponse;
        Action<DataResponse<
            UserSubAccountOptState, Page<UserSubAccountPageListVM>>> _getPageListResponse;

        public void Add(UserSubAccount subAccount, Action<UserSubAccountOptState> addResponse)
        {
            _addResponse = addResponse;
            subAccount.Password = TripleDES.Encrypt3DES(subAccount.Password);
            subAccount.PayPassword = TripleDES.Encrypt3DES(subAccount.PayPassword);
            var future = Global.SendToServer(subAccount, MessageType.AddUserSubAccountRequest);
            if (future == null)
            {
                AddResponse(UserSubAccountOptState.CannotConnectServer);
            }
        }

        public void Update(UserSubAccount subAccount, Action<UserSubAccountOptState> updateResponse)
        {
            _updateResponse = updateResponse;
            subAccount.Password = TripleDES.Encrypt3DES(subAccount.Password);
            subAccount.PayPassword = TripleDES.Encrypt3DES(subAccount.PayPassword);
            var future = Global.SendToServer(subAccount, MessageType.UpdateUserSubAccountRequest);
            if (future == null)
            {
                UpdateResponse(UserSubAccountOptState.CannotConnectServer);
            }
        }

        public void Delete(UserSubAccount subAccount, Action<UserSubAccountOptState> deleteResponse)
        {
            _deleteResponse = deleteResponse;
            var future = Global.SendToServer(subAccount, MessageType.DeleteUserSubAccountRequest);
            if (future == null)
            {
                DeleteResponse(UserSubAccountOptState.CannotConnectServer);
            }
        }

        public void GetList(Action<DataResponse<
            UserSubAccountOptState, IList<UserSubAccount>>> getListResponse)
        {
            _getListResponse = getListResponse;

            var future = Global.SendToServer(1, MessageType.GetUserSubAccountListRequest);
            if (future == null)
            {
                GetListResponse(new DataResponse<UserSubAccountOptState, IList<UserSubAccount>>
                {
                    State = UserSubAccountOptState.CannotConnectServer
                });
            }
        }

        public void GetPageList(PageListQueryInfo<UserSubAccountPageListQuery> info,
            Action<DataResponse<UserSubAccountOptState, Page<UserSubAccountPageListVM>>> getPageListResponse)
        {
            _getPageListResponse = getPageListResponse;
            var future = Global.SendToServer(info, MessageType.GetSubAccountPageListRequest);
            if (future == null)
            {
                GetPageListResponse(new DataResponse<UserSubAccountOptState, Page<UserSubAccountDetails>>
                {
                    State = UserSubAccountOptState.CannotConnectServer
                });
            }
        }

        public void AddResponse(UserSubAccountOptState state)
        {
            if (_addResponse != null)
            {
                _addResponse(state);
            }
        }

        public void DeleteResponse(UserSubAccountOptState state)
        {
            if (_deleteResponse != null)
            {
                _deleteResponse(state);
            }
        }

        public void UpdateResponse(UserSubAccountOptState state)
        {
            if (_updateResponse != null)
            {
                _updateResponse(state);
            }
        }

        public void GetListResponse(DataResponse<
            UserSubAccountOptState, IList<UserSubAccount>> listResponse)
        {
            if (_getListResponse != null)
            {
                _getListResponse(listResponse);
            }
        }

        public void GetPageListResponse(DataResponse<
            UserSubAccountOptState, Page<UserSubAccountDetails>> pageListResponse)
        {
            if (_getPageListResponse != null)
            {
                if (pageListResponse.State == UserSubAccountOptState.Successed)
                {
                    var list = pageListResponse.Data.List == null ? null :
                        pageListResponse.Data.List.Select<UserSubAccountDetails, UserSubAccountPageListVM>(details =>
                        {
                            var vm = new UserSubAccountPageListVM
                            {
                                Id = details.Id,
                                TaoBaoAccount = details.TaoBaoAccount,
                                HomePage = details.HomePage,          
                                Level = details.Level,
                                ConsumptionLevel = details.ConsumptionLevel,
                                Province = details.Province,
                                City = details.City,
                                District = details.District,
                                Age = details.Age,
                                Sex = details.Sex,
                                UpperLimitAmount = details.UpperLimitAmount,
                                UpperLimitNumber = details.UpperLimitNumber,
                                Commission = details.Commission,
                                ShippingAddress = details.ShippingAddress,
                                IsRealName = details.IsRealName,
                                IsBindingMobile = details.IsBindingMobile,
                                UserId = details.UserId,
                                UserAccount = details.User.Account,
                                DayOrderCount = details.DayOrderCount,
                                MonthOrderCount = details.MonthOrderCount,
                                OrderTypeDetails = details.OrderTypeDetails
                            };

                            if(details.UserLoginState != null)
                            {
                                vm.ClientLogin = details.UserLoginState.ClientLogin;
                                vm.IpAddress = details.UserLoginState.ClientLastLoginIpAddress;
                            }

                            return vm;
                        }).ToList();

                    _getPageListResponse(new DataResponse<UserSubAccountOptState, Page<UserSubAccountPageListVM>>
                    {
                        State = pageListResponse.State,
                        Data = new Page<UserSubAccountPageListVM>
                        {
                            Info = pageListResponse.Data.Info,
                            List = list
                        }
                    });
                    return;
                }

                _getPageListResponse(new DataResponse<UserSubAccountOptState, Page<UserSubAccountPageListVM>>
                {
                    State = pageListResponse.State
                });
            }
        }
    }
}