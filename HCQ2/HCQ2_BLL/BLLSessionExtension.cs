
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCQ2_IBLL;
namespace HCQ2_BLL
{
	public partial class BLLSession:IBLLSession
	{
	#region 01 业务接口
		IA01BLL iA01Bll;
		public IA01BLL A01
		{
			get
			{
				if(iA01Bll==null)
					iA01Bll=new A01BLL();
				return iA01Bll;
			}
			set
			{
				iA01Bll=value;
			}
		}
		#endregion

		#region 02 业务接口
		IA02BLL iA02Bll;
		public IA02BLL A02
		{
			get
			{
				if(iA02Bll==null)
					iA02Bll=new A02BLL();
				return iA02Bll;
			}
			set
			{
				iA02Bll=value;
			}
		}
		#endregion

		#region 03 业务接口
		IA03BLL iA03Bll;
		public IA03BLL A03
		{
			get
			{
				if(iA03Bll==null)
					iA03Bll=new A03BLL();
				return iA03Bll;
			}
			set
			{
				iA03Bll=value;
			}
		}
		#endregion

		#region 04 业务接口
		IA04BLL iA04Bll;
		public IA04BLL A04
		{
			get
			{
				if(iA04Bll==null)
					iA04Bll=new A04BLL();
				return iA04Bll;
			}
			set
			{
				iA04Bll=value;
			}
		}
		#endregion

		#region 05 业务接口
		IA19BLL iA19Bll;
		public IA19BLL A19
		{
			get
			{
				if(iA19Bll==null)
					iA19Bll=new A19BLL();
				return iA19Bll;
			}
			set
			{
				iA19Bll=value;
			}
		}
		#endregion

		#region 06 业务接口
		IATTACHJOBBLL iATTACHJOBBll;
		public IATTACHJOBBLL ATTACHJOB
		{
			get
			{
				if(iATTACHJOBBll==null)
					iATTACHJOBBll=new ATTACHJOBBLL();
				return iATTACHJOBBll;
			}
			set
			{
				iATTACHJOBBll=value;
			}
		}
		#endregion

		#region 07 业务接口
		IAuth_Define_DataScopeBLL iAuth_Define_DataScopeBll;
		public IAuth_Define_DataScopeBLL Auth_Define_DataScope
		{
			get
			{
				if(iAuth_Define_DataScopeBll==null)
					iAuth_Define_DataScopeBll=new Auth_Define_DataScopeBLL();
				return iAuth_Define_DataScopeBll;
			}
			set
			{
				iAuth_Define_DataScopeBll=value;
			}
		}
		#endregion

		#region 08 业务接口
		IAuth_Define_DataScopeItemBLL iAuth_Define_DataScopeItemBll;
		public IAuth_Define_DataScopeItemBLL Auth_Define_DataScopeItem
		{
			get
			{
				if(iAuth_Define_DataScopeItemBll==null)
					iAuth_Define_DataScopeItemBll=new Auth_Define_DataScopeItemBLL();
				return iAuth_Define_DataScopeItemBll;
			}
			set
			{
				iAuth_Define_DataScopeItemBll=value;
			}
		}
		#endregion

		#region 09 业务接口
		IAuth_Define_FuncBLL iAuth_Define_FuncBll;
		public IAuth_Define_FuncBLL Auth_Define_Func
		{
			get
			{
				if(iAuth_Define_FuncBll==null)
					iAuth_Define_FuncBll=new Auth_Define_FuncBLL();
				return iAuth_Define_FuncBll;
			}
			set
			{
				iAuth_Define_FuncBll=value;
			}
		}
		#endregion

		#region 10 业务接口
		IAuth_Define_SetDBBLL iAuth_Define_SetDBBll;
		public IAuth_Define_SetDBBLL Auth_Define_SetDB
		{
			get
			{
				if(iAuth_Define_SetDBBll==null)
					iAuth_Define_SetDBBll=new Auth_Define_SetDBBLL();
				return iAuth_Define_SetDBBll;
			}
			set
			{
				iAuth_Define_SetDBBll=value;
			}
		}
		#endregion

		#region 11 业务接口
		IAuth_Define_SetItemBLL iAuth_Define_SetItemBll;
		public IAuth_Define_SetItemBLL Auth_Define_SetItem
		{
			get
			{
				if(iAuth_Define_SetItemBll==null)
					iAuth_Define_SetItemBll=new Auth_Define_SetItemBLL();
				return iAuth_Define_SetItemBll;
			}
			set
			{
				iAuth_Define_SetItemBll=value;
			}
		}
		#endregion

		#region 12 业务接口
		IAuth_Define_SetTableBLL iAuth_Define_SetTableBll;
		public IAuth_Define_SetTableBLL Auth_Define_SetTable
		{
			get
			{
				if(iAuth_Define_SetTableBll==null)
					iAuth_Define_SetTableBll=new Auth_Define_SetTableBLL();
				return iAuth_Define_SetTableBll;
			}
			set
			{
				iAuth_Define_SetTableBll=value;
			}
		}
		#endregion

		#region 13 业务接口
		IAuth_OrgRoleBLL iAuth_OrgRoleBll;
		public IAuth_OrgRoleBLL Auth_OrgRole
		{
			get
			{
				if(iAuth_OrgRoleBll==null)
					iAuth_OrgRoleBll=new Auth_OrgRoleBLL();
				return iAuth_OrgRoleBll;
			}
			set
			{
				iAuth_OrgRoleBll=value;
			}
		}
		#endregion

		#region 14 业务接口
		IAuth_PermissionBLL iAuth_PermissionBll;
		public IAuth_PermissionBLL Auth_Permission
		{
			get
			{
				if(iAuth_PermissionBll==null)
					iAuth_PermissionBll=new Auth_PermissionBLL();
				return iAuth_PermissionBll;
			}
			set
			{
				iAuth_PermissionBll=value;
			}
		}
		#endregion

		#region 15 业务接口
		IAuth_PermissionScopeBLL iAuth_PermissionScopeBll;
		public IAuth_PermissionScopeBLL Auth_PermissionScope
		{
			get
			{
				if(iAuth_PermissionScopeBll==null)
					iAuth_PermissionScopeBll=new Auth_PermissionScopeBLL();
				return iAuth_PermissionScopeBll;
			}
			set
			{
				iAuth_PermissionScopeBll=value;
			}
		}
		#endregion

		#region 16 业务接口
		IAuth_RoleBLL iAuth_RoleBll;
		public IAuth_RoleBLL Auth_Role
		{
			get
			{
				if(iAuth_RoleBll==null)
					iAuth_RoleBll=new Auth_RoleBLL();
				return iAuth_RoleBll;
			}
			set
			{
				iAuth_RoleBll=value;
			}
		}
		#endregion

		#region 17 业务接口
		IAuth_SecretLoginBLL iAuth_SecretLoginBll;
		public IAuth_SecretLoginBLL Auth_SecretLogin
		{
			get
			{
				if(iAuth_SecretLoginBll==null)
					iAuth_SecretLoginBll=new Auth_SecretLoginBLL();
				return iAuth_SecretLoginBll;
			}
			set
			{
				iAuth_SecretLoginBll=value;
			}
		}
		#endregion

		#region 18 业务接口
		IAuth_UserBLL iAuth_UserBll;
		public IAuth_UserBLL Auth_User
		{
			get
			{
				if(iAuth_UserBll==null)
					iAuth_UserBll=new Auth_UserBLL();
				return iAuth_UserBll;
			}
			set
			{
				iAuth_UserBll=value;
			}
		}
		#endregion

		#region 19 业务接口
		IAuth_UserGroupBLL iAuth_UserGroupBll;
		public IAuth_UserGroupBLL Auth_UserGroup
		{
			get
			{
				if(iAuth_UserGroupBll==null)
					iAuth_UserGroupBll=new Auth_UserGroupBLL();
				return iAuth_UserGroupBll;
			}
			set
			{
				iAuth_UserGroupBll=value;
			}
		}
		#endregion

		#region 20 业务接口
		IAuth_UserGroupRoleBLL iAuth_UserGroupRoleBll;
		public IAuth_UserGroupRoleBLL Auth_UserGroupRole
		{
			get
			{
				if(iAuth_UserGroupRoleBll==null)
					iAuth_UserGroupRoleBll=new Auth_UserGroupRoleBLL();
				return iAuth_UserGroupRoleBll;
			}
			set
			{
				iAuth_UserGroupRoleBll=value;
			}
		}
		#endregion

		#region 21 业务接口
		IAuth_UserLogonBLL iAuth_UserLogonBll;
		public IAuth_UserLogonBLL Auth_UserLogon
		{
			get
			{
				if(iAuth_UserLogonBll==null)
					iAuth_UserLogonBll=new Auth_UserLogonBLL();
				return iAuth_UserLogonBll;
			}
			set
			{
				iAuth_UserLogonBll=value;
			}
		}
		#endregion

		#region 22 业务接口
		IAuth_UserRoleBLL iAuth_UserRoleBll;
		public IAuth_UserRoleBLL Auth_UserRole
		{
			get
			{
				if(iAuth_UserRoleBll==null)
					iAuth_UserRoleBll=new Auth_UserRoleBLL();
				return iAuth_UserRoleBll;
			}
			set
			{
				iAuth_UserRoleBll=value;
			}
		}
		#endregion

		#region 23 业务接口
		IAuth_UserWeixinBLL iAuth_UserWeixinBll;
		public IAuth_UserWeixinBLL Auth_UserWeixin
		{
			get
			{
				if(iAuth_UserWeixinBll==null)
					iAuth_UserWeixinBll=new Auth_UserWeixinBLL();
				return iAuth_UserWeixinBll;
			}
			set
			{
				iAuth_UserWeixinBll=value;
			}
		}
		#endregion

		#region 24 业务接口
		IB01BLL iB01Bll;
		public IB01BLL B01
		{
			get
			{
				if(iB01Bll==null)
					iB01Bll=new B01BLL();
				return iB01Bll;
			}
			set
			{
				iB01Bll=value;
			}
		}
		#endregion

		#region 25 业务接口
		IBB_CashDetailBLL iBB_CashDetailBll;
		public IBB_CashDetailBLL BB_CashDetail
		{
			get
			{
				if(iBB_CashDetailBll==null)
					iBB_CashDetailBll=new BB_CashDetailBLL();
				return iBB_CashDetailBll;
			}
			set
			{
				iBB_CashDetailBll=value;
			}
		}
		#endregion

		#region 26 业务接口
		IBB_DWBLL iBB_DWBll;
		public IBB_DWBLL BB_DW
		{
			get
			{
				if(iBB_DWBll==null)
					iBB_DWBll=new BB_DWBLL();
				return iBB_DWBll;
			}
			set
			{
				iBB_DWBll=value;
			}
		}
		#endregion

		#region 27 业务接口
		IBB_DWLevelBLL iBB_DWLevelBll;
		public IBB_DWLevelBLL BB_DWLevel
		{
			get
			{
				if(iBB_DWLevelBll==null)
					iBB_DWLevelBll=new BB_DWLevelBLL();
				return iBB_DWLevelBll;
			}
			set
			{
				iBB_DWLevelBll=value;
			}
		}
		#endregion

		#region 28 业务接口
		IBB_DWLevelUserBLL iBB_DWLevelUserBll;
		public IBB_DWLevelUserBLL BB_DWLevelUser
		{
			get
			{
				if(iBB_DWLevelUserBll==null)
					iBB_DWLevelUserBll=new BB_DWLevelUserBLL();
				return iBB_DWLevelUserBll;
			}
			set
			{
				iBB_DWLevelUserBll=value;
			}
		}
		#endregion

		#region 29 业务接口
		IBB_DWStateBLL iBB_DWStateBll;
		public IBB_DWStateBLL BB_DWState
		{
			get
			{
				if(iBB_DWStateBll==null)
					iBB_DWStateBll=new BB_DWStateBLL();
				return iBB_DWStateBll;
			}
			set
			{
				iBB_DWStateBll=value;
			}
		}
		#endregion

		#region 30 业务接口
		IBB_DWStateCheckResultBLL iBB_DWStateCheckResultBll;
		public IBB_DWStateCheckResultBLL BB_DWStateCheckResult
		{
			get
			{
				if(iBB_DWStateCheckResultBll==null)
					iBB_DWStateCheckResultBll=new BB_DWStateCheckResultBLL();
				return iBB_DWStateCheckResultBll;
			}
			set
			{
				iBB_DWStateCheckResultBll=value;
			}
		}
		#endregion

		#region 31 业务接口
		IBB_DWTotalBLL iBB_DWTotalBll;
		public IBB_DWTotalBLL BB_DWTotal
		{
			get
			{
				if(iBB_DWTotalBll==null)
					iBB_DWTotalBll=new BB_DWTotalBLL();
				return iBB_DWTotalBll;
			}
			set
			{
				iBB_DWTotalBll=value;
			}
		}
		#endregion

		#region 32 业务接口
		IBB_FacilityPreserveBLL iBB_FacilityPreserveBll;
		public IBB_FacilityPreserveBLL BB_FacilityPreserve
		{
			get
			{
				if(iBB_FacilityPreserveBll==null)
					iBB_FacilityPreserveBll=new BB_FacilityPreserveBLL();
				return iBB_FacilityPreserveBll;
			}
			set
			{
				iBB_FacilityPreserveBll=value;
			}
		}
		#endregion

		#region 33 业务接口
		IBB_FetchDataSetupBLL iBB_FetchDataSetupBll;
		public IBB_FetchDataSetupBLL BB_FetchDataSetup
		{
			get
			{
				if(iBB_FetchDataSetupBll==null)
					iBB_FetchDataSetupBll=new BB_FetchDataSetupBLL();
				return iBB_FetchDataSetupBll;
			}
			set
			{
				iBB_FetchDataSetupBll=value;
			}
		}
		#endregion

		#region 34 业务接口
		IBB_FetchFCBLL iBB_FetchFCBll;
		public IBB_FetchFCBLL BB_FetchFC
		{
			get
			{
				if(iBB_FetchFCBll==null)
					iBB_FetchFCBll=new BB_FetchFCBLL();
				return iBB_FetchFCBll;
			}
			set
			{
				iBB_FetchFCBll=value;
			}
		}
		#endregion

		#region 35 业务接口
		IBB_FetchNumberFuncBLL iBB_FetchNumberFuncBll;
		public IBB_FetchNumberFuncBLL BB_FetchNumberFunc
		{
			get
			{
				if(iBB_FetchNumberFuncBll==null)
					iBB_FetchNumberFuncBll=new BB_FetchNumberFuncBLL();
				return iBB_FetchNumberFuncBll;
			}
			set
			{
				iBB_FetchNumberFuncBll=value;
			}
		}
		#endregion

		#region 36 业务接口
		IBB_FetchPoolLogBLL iBB_FetchPoolLogBll;
		public IBB_FetchPoolLogBLL BB_FetchPoolLog
		{
			get
			{
				if(iBB_FetchPoolLogBll==null)
					iBB_FetchPoolLogBll=new BB_FetchPoolLogBLL();
				return iBB_FetchPoolLogBll;
			}
			set
			{
				iBB_FetchPoolLogBll=value;
			}
		}
		#endregion

		#region 37 业务接口
		IBB_InternalReciveLogBLL iBB_InternalReciveLogBll;
		public IBB_InternalReciveLogBLL BB_InternalReciveLog
		{
			get
			{
				if(iBB_InternalReciveLogBll==null)
					iBB_InternalReciveLogBll=new BB_InternalReciveLogBLL();
				return iBB_InternalReciveLogBll;
			}
			set
			{
				iBB_InternalReciveLogBll=value;
			}
		}
		#endregion

		#region 38 业务接口
		IBB_InternalSendBLL iBB_InternalSendBll;
		public IBB_InternalSendBLL BB_InternalSend
		{
			get
			{
				if(iBB_InternalSendBll==null)
					iBB_InternalSendBll=new BB_InternalSendBLL();
				return iBB_InternalSendBll;
			}
			set
			{
				iBB_InternalSendBll=value;
			}
		}
		#endregion

		#region 39 业务接口
		IBB_ItemPreserveBLL iBB_ItemPreserveBll;
		public IBB_ItemPreserveBLL BB_ItemPreserve
		{
			get
			{
				if(iBB_ItemPreserveBll==null)
					iBB_ItemPreserveBll=new BB_ItemPreserveBLL();
				return iBB_ItemPreserveBll;
			}
			set
			{
				iBB_ItemPreserveBll=value;
			}
		}
		#endregion

		#region 40 业务接口
		IBB_PactDetailFlieBLL iBB_PactDetailFlieBll;
		public IBB_PactDetailFlieBLL BB_PactDetailFlie
		{
			get
			{
				if(iBB_PactDetailFlieBll==null)
					iBB_PactDetailFlieBll=new BB_PactDetailFlieBLL();
				return iBB_PactDetailFlieBll;
			}
			set
			{
				iBB_PactDetailFlieBll=value;
			}
		}
		#endregion

		#region 41 业务接口
		IBB_ServiceUserBLL iBB_ServiceUserBll;
		public IBB_ServiceUserBLL BB_ServiceUser
		{
			get
			{
				if(iBB_ServiceUserBll==null)
					iBB_ServiceUserBll=new BB_ServiceUserBLL();
				return iBB_ServiceUserBll;
			}
			set
			{
				iBB_ServiceUserBll=value;
			}
		}
		#endregion

		#region 42 业务接口
		IBB_SJ_DataSpecialBLL iBB_SJ_DataSpecialBll;
		public IBB_SJ_DataSpecialBLL BB_SJ_DataSpecial
		{
			get
			{
				if(iBB_SJ_DataSpecialBll==null)
					iBB_SJ_DataSpecialBll=new BB_SJ_DataSpecialBLL();
				return iBB_SJ_DataSpecialBll;
			}
			set
			{
				iBB_SJ_DataSpecialBll=value;
			}
		}
		#endregion

		#region 43 业务接口
		IBB_SJ_NoteFloatBLL iBB_SJ_NoteFloatBll;
		public IBB_SJ_NoteFloatBLL BB_SJ_NoteFloat
		{
			get
			{
				if(iBB_SJ_NoteFloatBll==null)
					iBB_SJ_NoteFloatBll=new BB_SJ_NoteFloatBLL();
				return iBB_SJ_NoteFloatBll;
			}
			set
			{
				iBB_SJ_NoteFloatBll=value;
			}
		}
		#endregion

		#region 44 业务接口
		IBB_SJ_NoteTextBLL iBB_SJ_NoteTextBll;
		public IBB_SJ_NoteTextBLL BB_SJ_NoteText
		{
			get
			{
				if(iBB_SJ_NoteTextBll==null)
					iBB_SJ_NoteTextBll=new BB_SJ_NoteTextBLL();
				return iBB_SJ_NoteTextBll;
			}
			set
			{
				iBB_SJ_NoteTextBll=value;
			}
		}
		#endregion

		#region 45 业务接口
		IBB_TBBLL iBB_TBBll;
		public IBB_TBBLL BB_TB
		{
			get
			{
				if(iBB_TBBll==null)
					iBB_TBBll=new BB_TBBLL();
				return iBB_TBBll;
			}
			set
			{
				iBB_TBBll=value;
			}
		}
		#endregion

		#region 46 业务接口
		IBB_TBClassBLL iBB_TBClassBll;
		public IBB_TBClassBLL BB_TBClass
		{
			get
			{
				if(iBB_TBClassBll==null)
					iBB_TBClassBll=new BB_TBClassBLL();
				return iBB_TBClassBll;
			}
			set
			{
				iBB_TBClassBll=value;
			}
		}
		#endregion

		#region 47 业务接口
		IBB_TBDataHintBLL iBB_TBDataHintBll;
		public IBB_TBDataHintBLL BB_TBDataHint
		{
			get
			{
				if(iBB_TBDataHintBll==null)
					iBB_TBDataHintBll=new BB_TBDataHintBLL();
				return iBB_TBDataHintBll;
			}
			set
			{
				iBB_TBDataHintBll=value;
			}
		}
		#endregion

		#region 48 业务接口
		IBB_TBItemsBLL iBB_TBItemsBll;
		public IBB_TBItemsBLL BB_TBItems
		{
			get
			{
				if(iBB_TBItemsBll==null)
					iBB_TBItemsBll=new BB_TBItemsBLL();
				return iBB_TBItemsBll;
			}
			set
			{
				iBB_TBItemsBll=value;
			}
		}
		#endregion

		#region 49 业务接口
		IBB_TBRemarkUserLevelBLL iBB_TBRemarkUserLevelBll;
		public IBB_TBRemarkUserLevelBLL BB_TBRemarkUserLevel
		{
			get
			{
				if(iBB_TBRemarkUserLevelBll==null)
					iBB_TBRemarkUserLevelBll=new BB_TBRemarkUserLevelBLL();
				return iBB_TBRemarkUserLevelBll;
			}
			set
			{
				iBB_TBRemarkUserLevelBll=value;
			}
		}
		#endregion

		#region 50 业务接口
		IBB_TBRemarkUsersBLL iBB_TBRemarkUsersBll;
		public IBB_TBRemarkUsersBLL BB_TBRemarkUsers
		{
			get
			{
				if(iBB_TBRemarkUsersBll==null)
					iBB_TBRemarkUsersBll=new BB_TBRemarkUsersBLL();
				return iBB_TBRemarkUsersBll;
			}
			set
			{
				iBB_TBRemarkUsersBll=value;
			}
		}
		#endregion

		#region 51 业务接口
		IBB_TotalFCBLL iBB_TotalFCBll;
		public IBB_TotalFCBLL BB_TotalFC
		{
			get
			{
				if(iBB_TotalFCBll==null)
					iBB_TotalFCBll=new BB_TotalFCBLL();
				return iBB_TotalFCBll;
			}
			set
			{
				iBB_TotalFCBll=value;
			}
		}
		#endregion

		#region 52 业务接口
		IBB_TrackRecordBLL iBB_TrackRecordBll;
		public IBB_TrackRecordBLL BB_TrackRecord
		{
			get
			{
				if(iBB_TrackRecordBll==null)
					iBB_TrackRecordBll=new BB_TrackRecordBLL();
				return iBB_TrackRecordBll;
			}
			set
			{
				iBB_TrackRecordBll=value;
			}
		}
		#endregion

		#region 53 业务接口
		IBB_TypeBLL iBB_TypeBll;
		public IBB_TypeBLL BB_Type
		{
			get
			{
				if(iBB_TypeBll==null)
					iBB_TypeBll=new BB_TypeBLL();
				return iBB_TypeBll;
			}
			set
			{
				iBB_TypeBll=value;
			}
		}
		#endregion

		#region 54 业务接口
		IBB_TypeCycleBLL iBB_TypeCycleBll;
		public IBB_TypeCycleBLL BB_TypeCycle
		{
			get
			{
				if(iBB_TypeCycleBll==null)
					iBB_TypeCycleBll=new BB_TypeCycleBLL();
				return iBB_TypeCycleBll;
			}
			set
			{
				iBB_TypeCycleBll=value;
			}
		}
		#endregion

		#region 55 业务接口
		IBB_UpDataLogBLL iBB_UpDataLogBll;
		public IBB_UpDataLogBLL BB_UpDataLog
		{
			get
			{
				if(iBB_UpDataLogBll==null)
					iBB_UpDataLogBll=new BB_UpDataLogBLL();
				return iBB_UpDataLogBll;
			}
			set
			{
				iBB_UpDataLogBll=value;
			}
		}
		#endregion

		#region 56 业务接口
		IBB_ZBBLL iBB_ZBBll;
		public IBB_ZBBLL BB_ZB
		{
			get
			{
				if(iBB_ZBBll==null)
					iBB_ZBBll=new BB_ZBBLL();
				return iBB_ZBBll;
			}
			set
			{
				iBB_ZBBll=value;
			}
		}
		#endregion

		#region 57 业务接口
		IBB_ZBConditionBLL iBB_ZBConditionBll;
		public IBB_ZBConditionBLL BB_ZBCondition
		{
			get
			{
				if(iBB_ZBConditionBll==null)
					iBB_ZBConditionBll=new BB_ZBConditionBLL();
				return iBB_ZBConditionBll;
			}
			set
			{
				iBB_ZBConditionBll=value;
			}
		}
		#endregion

		#region 58 业务接口
		IBB_ZBVarItemsBLL iBB_ZBVarItemsBll;
		public IBB_ZBVarItemsBLL BB_ZBVarItems
		{
			get
			{
				if(iBB_ZBVarItemsBll==null)
					iBB_ZBVarItemsBll=new BB_ZBVarItemsBLL();
				return iBB_ZBVarItemsBll;
			}
			set
			{
				iBB_ZBVarItemsBll=value;
			}
		}
		#endregion

		#region 59 业务接口
		IBMQ_DocumentBLL iBMQ_DocumentBll;
		public IBMQ_DocumentBLL BMQ_Document
		{
			get
			{
				if(iBMQ_DocumentBll==null)
					iBMQ_DocumentBll=new BMQ_DocumentBLL();
				return iBMQ_DocumentBll;
			}
			set
			{
				iBMQ_DocumentBll=value;
			}
		}
		#endregion

		#region 60 业务接口
		IBPM_AgencyRuleBLL iBPM_AgencyRuleBll;
		public IBPM_AgencyRuleBLL BPM_AgencyRule
		{
			get
			{
				if(iBPM_AgencyRuleBll==null)
					iBPM_AgencyRuleBll=new BPM_AgencyRuleBLL();
				return iBPM_AgencyRuleBll;
			}
			set
			{
				iBPM_AgencyRuleBll=value;
			}
		}
		#endregion

		#region 61 业务接口
		IBPM_AgencyRuleAssigneeBLL iBPM_AgencyRuleAssigneeBll;
		public IBPM_AgencyRuleAssigneeBLL BPM_AgencyRuleAssignee
		{
			get
			{
				if(iBPM_AgencyRuleAssigneeBll==null)
					iBPM_AgencyRuleAssigneeBll=new BPM_AgencyRuleAssigneeBLL();
				return iBPM_AgencyRuleAssigneeBll;
			}
			set
			{
				iBPM_AgencyRuleAssigneeBll=value;
			}
		}
		#endregion

		#region 62 业务接口
		IBPM_AgencyRuleProcessBLL iBPM_AgencyRuleProcessBll;
		public IBPM_AgencyRuleProcessBLL BPM_AgencyRuleProcess
		{
			get
			{
				if(iBPM_AgencyRuleProcessBll==null)
					iBPM_AgencyRuleProcessBll=new BPM_AgencyRuleProcessBLL();
				return iBPM_AgencyRuleProcessBll;
			}
			set
			{
				iBPM_AgencyRuleProcessBll=value;
			}
		}
		#endregion

		#region 63 业务接口
		IBPM_D_AskForLeaveDemo_MainBLL iBPM_D_AskForLeaveDemo_MainBll;
		public IBPM_D_AskForLeaveDemo_MainBLL BPM_D_AskForLeaveDemo_Main
		{
			get
			{
				if(iBPM_D_AskForLeaveDemo_MainBll==null)
					iBPM_D_AskForLeaveDemo_MainBll=new BPM_D_AskForLeaveDemo_MainBLL();
				return iBPM_D_AskForLeaveDemo_MainBll;
			}
			set
			{
				iBPM_D_AskForLeaveDemo_MainBll=value;
			}
		}
		#endregion

		#region 64 业务接口
		IBPM_D_Leave_MainBLL iBPM_D_Leave_MainBll;
		public IBPM_D_Leave_MainBLL BPM_D_Leave_Main
		{
			get
			{
				if(iBPM_D_Leave_MainBll==null)
					iBPM_D_Leave_MainBll=new BPM_D_Leave_MainBLL();
				return iBPM_D_Leave_MainBll;
			}
			set
			{
				iBPM_D_Leave_MainBll=value;
			}
		}
		#endregion

		#region 65 业务接口
		IBPM_D_NewEmployees_MainBLL iBPM_D_NewEmployees_MainBll;
		public IBPM_D_NewEmployees_MainBLL BPM_D_NewEmployees_Main
		{
			get
			{
				if(iBPM_D_NewEmployees_MainBll==null)
					iBPM_D_NewEmployees_MainBll=new BPM_D_NewEmployees_MainBLL();
				return iBPM_D_NewEmployees_MainBll;
			}
			set
			{
				iBPM_D_NewEmployees_MainBll=value;
			}
		}
		#endregion

		#region 66 业务接口
		IBPM_Define_ActionListenerBLL iBPM_Define_ActionListenerBll;
		public IBPM_Define_ActionListenerBLL BPM_Define_ActionListener
		{
			get
			{
				if(iBPM_Define_ActionListenerBll==null)
					iBPM_Define_ActionListenerBll=new BPM_Define_ActionListenerBLL();
				return iBPM_Define_ActionListenerBll;
			}
			set
			{
				iBPM_Define_ActionListenerBll=value;
			}
		}
		#endregion

		#region 67 业务接口
		IBPM_Define_ActorAdapterBLL iBPM_Define_ActorAdapterBll;
		public IBPM_Define_ActorAdapterBLL BPM_Define_ActorAdapter
		{
			get
			{
				if(iBPM_Define_ActorAdapterBll==null)
					iBPM_Define_ActorAdapterBll=new BPM_Define_ActorAdapterBLL();
				return iBPM_Define_ActorAdapterBll;
			}
			set
			{
				iBPM_Define_ActorAdapterBll=value;
			}
		}
		#endregion

		#region 68 业务接口
		IBPM_Define_ActorAdapter_bakBLL iBPM_Define_ActorAdapter_bakBll;
		public IBPM_Define_ActorAdapter_bakBLL BPM_Define_ActorAdapter_bak
		{
			get
			{
				if(iBPM_Define_ActorAdapter_bakBll==null)
					iBPM_Define_ActorAdapter_bakBll=new BPM_Define_ActorAdapter_bakBLL();
				return iBPM_Define_ActorAdapter_bakBll;
			}
			set
			{
				iBPM_Define_ActorAdapter_bakBll=value;
			}
		}
		#endregion

		#region 69 业务接口
		IBPM_Define_CatalogBLL iBPM_Define_CatalogBll;
		public IBPM_Define_CatalogBLL BPM_Define_Catalog
		{
			get
			{
				if(iBPM_Define_CatalogBll==null)
					iBPM_Define_CatalogBll=new BPM_Define_CatalogBLL();
				return iBPM_Define_CatalogBll;
			}
			set
			{
				iBPM_Define_CatalogBll=value;
			}
		}
		#endregion

		#region 70 业务接口
		IBPM_Define_ConstBLL iBPM_Define_ConstBll;
		public IBPM_Define_ConstBLL BPM_Define_Const
		{
			get
			{
				if(iBPM_Define_ConstBll==null)
					iBPM_Define_ConstBll=new BPM_Define_ConstBLL();
				return iBPM_Define_ConstBll;
			}
			set
			{
				iBPM_Define_ConstBll=value;
			}
		}
		#endregion

		#region 71 业务接口
		IBPM_Define_DataModelBLL iBPM_Define_DataModelBll;
		public IBPM_Define_DataModelBLL BPM_Define_DataModel
		{
			get
			{
				if(iBPM_Define_DataModelBll==null)
					iBPM_Define_DataModelBll=new BPM_Define_DataModelBLL();
				return iBPM_Define_DataModelBll;
			}
			set
			{
				iBPM_Define_DataModelBll=value;
			}
		}
		#endregion

		#region 72 业务接口
		IBPM_Define_FormBLL iBPM_Define_FormBll;
		public IBPM_Define_FormBLL BPM_Define_Form
		{
			get
			{
				if(iBPM_Define_FormBll==null)
					iBPM_Define_FormBll=new BPM_Define_FormBLL();
				return iBPM_Define_FormBll;
			}
			set
			{
				iBPM_Define_FormBll=value;
			}
		}
		#endregion

		#region 73 业务接口
		IBPM_Define_PackageBLL iBPM_Define_PackageBll;
		public IBPM_Define_PackageBLL BPM_Define_Package
		{
			get
			{
				if(iBPM_Define_PackageBll==null)
					iBPM_Define_PackageBll=new BPM_Define_PackageBLL();
				return iBPM_Define_PackageBll;
			}
			set
			{
				iBPM_Define_PackageBll=value;
			}
		}
		#endregion

		#region 74 业务接口
		IBPM_Define_ProcessDraftBLL iBPM_Define_ProcessDraftBll;
		public IBPM_Define_ProcessDraftBLL BPM_Define_ProcessDraft
		{
			get
			{
				if(iBPM_Define_ProcessDraftBll==null)
					iBPM_Define_ProcessDraftBll=new BPM_Define_ProcessDraftBLL();
				return iBPM_Define_ProcessDraftBll;
			}
			set
			{
				iBPM_Define_ProcessDraftBll=value;
			}
		}
		#endregion

		#region 75 业务接口
		IBPM_Define_ProcessPublishedBLL iBPM_Define_ProcessPublishedBll;
		public IBPM_Define_ProcessPublishedBLL BPM_Define_ProcessPublished
		{
			get
			{
				if(iBPM_Define_ProcessPublishedBll==null)
					iBPM_Define_ProcessPublishedBll=new BPM_Define_ProcessPublishedBLL();
				return iBPM_Define_ProcessPublishedBll;
			}
			set
			{
				iBPM_Define_ProcessPublishedBll=value;
			}
		}
		#endregion

		#region 76 业务接口
		IBPM_Define_SchemeBLL iBPM_Define_SchemeBll;
		public IBPM_Define_SchemeBLL BPM_Define_Scheme
		{
			get
			{
				if(iBPM_Define_SchemeBll==null)
					iBPM_Define_SchemeBll=new BPM_Define_SchemeBLL();
				return iBPM_Define_SchemeBll;
			}
			set
			{
				iBPM_Define_SchemeBll=value;
			}
		}
		#endregion

		#region 77 业务接口
		IBPM_Run_InstanceBLL iBPM_Run_InstanceBll;
		public IBPM_Run_InstanceBLL BPM_Run_Instance
		{
			get
			{
				if(iBPM_Run_InstanceBll==null)
					iBPM_Run_InstanceBll=new BPM_Run_InstanceBLL();
				return iBPM_Run_InstanceBll;
			}
			set
			{
				iBPM_Run_InstanceBll=value;
			}
		}
		#endregion

		#region 78 业务接口
		IBPM_Run_ProcessLogBLL iBPM_Run_ProcessLogBll;
		public IBPM_Run_ProcessLogBLL BPM_Run_ProcessLog
		{
			get
			{
				if(iBPM_Run_ProcessLogBll==null)
					iBPM_Run_ProcessLogBll=new BPM_Run_ProcessLogBLL();
				return iBPM_Run_ProcessLogBll;
			}
			set
			{
				iBPM_Run_ProcessLogBll=value;
			}
		}
		#endregion

		#region 79 业务接口
		IBPM_Run_SchemeJobBLL iBPM_Run_SchemeJobBll;
		public IBPM_Run_SchemeJobBLL BPM_Run_SchemeJob
		{
			get
			{
				if(iBPM_Run_SchemeJobBll==null)
					iBPM_Run_SchemeJobBll=new BPM_Run_SchemeJobBLL();
				return iBPM_Run_SchemeJobBll;
			}
			set
			{
				iBPM_Run_SchemeJobBll=value;
			}
		}
		#endregion

		#region 80 业务接口
		IBPM_Run_SharedTaskBLL iBPM_Run_SharedTaskBll;
		public IBPM_Run_SharedTaskBLL BPM_Run_SharedTask
		{
			get
			{
				if(iBPM_Run_SharedTaskBll==null)
					iBPM_Run_SharedTaskBll=new BPM_Run_SharedTaskBLL();
				return iBPM_Run_SharedTaskBll;
			}
			set
			{
				iBPM_Run_SharedTaskBll=value;
			}
		}
		#endregion

		#region 81 业务接口
		IBPM_Run_TrackingBLL iBPM_Run_TrackingBll;
		public IBPM_Run_TrackingBLL BPM_Run_Tracking
		{
			get
			{
				if(iBPM_Run_TrackingBll==null)
					iBPM_Run_TrackingBll=new BPM_Run_TrackingBLL();
				return iBPM_Run_TrackingBll;
			}
			set
			{
				iBPM_Run_TrackingBll=value;
			}
		}
		#endregion

		#region 82 业务接口
		IBPM_Run_UrgedBLL iBPM_Run_UrgedBll;
		public IBPM_Run_UrgedBLL BPM_Run_Urged
		{
			get
			{
				if(iBPM_Run_UrgedBll==null)
					iBPM_Run_UrgedBll=new BPM_Run_UrgedBLL();
				return iBPM_Run_UrgedBll;
			}
			set
			{
				iBPM_Run_UrgedBll=value;
			}
		}
		#endregion

		#region 83 业务接口
		IBPM_Run_VariableBLL iBPM_Run_VariableBll;
		public IBPM_Run_VariableBLL BPM_Run_Variable
		{
			get
			{
				if(iBPM_Run_VariableBll==null)
					iBPM_Run_VariableBll=new BPM_Run_VariableBLL();
				return iBPM_Run_VariableBll;
			}
			set
			{
				iBPM_Run_VariableBll=value;
			}
		}
		#endregion

		#region 84 业务接口
		IBPM_Run_WorkTaskBLL iBPM_Run_WorkTaskBll;
		public IBPM_Run_WorkTaskBLL BPM_Run_WorkTask
		{
			get
			{
				if(iBPM_Run_WorkTaskBll==null)
					iBPM_Run_WorkTaskBll=new BPM_Run_WorkTaskBLL();
				return iBPM_Run_WorkTaskBll;
			}
			set
			{
				iBPM_Run_WorkTaskBll=value;
			}
		}
		#endregion

		#region 85 业务接口
		IBPM_Run_WorkTaskOpinionBLL iBPM_Run_WorkTaskOpinionBll;
		public IBPM_Run_WorkTaskOpinionBLL BPM_Run_WorkTaskOpinion
		{
			get
			{
				if(iBPM_Run_WorkTaskOpinionBll==null)
					iBPM_Run_WorkTaskOpinionBll=new BPM_Run_WorkTaskOpinionBLL();
				return iBPM_Run_WorkTaskOpinionBll;
			}
			set
			{
				iBPM_Run_WorkTaskOpinionBll=value;
			}
		}
		#endregion

		#region 86 业务接口
		IBPM_UserExtInfoBLL iBPM_UserExtInfoBll;
		public IBPM_UserExtInfoBLL BPM_UserExtInfo
		{
			get
			{
				if(iBPM_UserExtInfoBll==null)
					iBPM_UserExtInfoBll=new BPM_UserExtInfoBLL();
				return iBPM_UserExtInfoBll;
			}
			set
			{
				iBPM_UserExtInfoBll=value;
			}
		}
		#endregion

		#region 87 业务接口
		IBPM_UsuallyOpinionBLL iBPM_UsuallyOpinionBll;
		public IBPM_UsuallyOpinionBLL BPM_UsuallyOpinion
		{
			get
			{
				if(iBPM_UsuallyOpinionBll==null)
					iBPM_UsuallyOpinionBll=new BPM_UsuallyOpinionBLL();
				return iBPM_UsuallyOpinionBll;
			}
			set
			{
				iBPM_UsuallyOpinionBll=value;
			}
		}
		#endregion

		#region 88 业务接口
		ICache_BlobInfoBLL iCache_BlobInfoBll;
		public ICache_BlobInfoBLL Cache_BlobInfo
		{
			get
			{
				if(iCache_BlobInfoBll==null)
					iCache_BlobInfoBll=new Cache_BlobInfoBLL();
				return iCache_BlobInfoBll;
			}
			set
			{
				iCache_BlobInfoBll=value;
			}
		}
		#endregion

		#region 89 业务接口
		ICache_StatDataBLL iCache_StatDataBll;
		public ICache_StatDataBLL Cache_StatData
		{
			get
			{
				if(iCache_StatDataBll==null)
					iCache_StatDataBll=new Cache_StatDataBLL();
				return iCache_StatDataBll;
			}
			set
			{
				iCache_StatDataBll=value;
			}
		}
		#endregion

		#region 90 业务接口
		ICom_CatalogBLL iCom_CatalogBll;
		public ICom_CatalogBLL Com_Catalog
		{
			get
			{
				if(iCom_CatalogBll==null)
					iCom_CatalogBll=new Com_CatalogBLL();
				return iCom_CatalogBll;
			}
			set
			{
				iCom_CatalogBll=value;
			}
		}
		#endregion

		#region 91 业务接口
		ICom_FormulaBLL iCom_FormulaBll;
		public ICom_FormulaBLL Com_Formula
		{
			get
			{
				if(iCom_FormulaBll==null)
					iCom_FormulaBll=new Com_FormulaBLL();
				return iCom_FormulaBll;
			}
			set
			{
				iCom_FormulaBll=value;
			}
		}
		#endregion

		#region 92 业务接口
		ICom_JetTableItemsBLL iCom_JetTableItemsBll;
		public ICom_JetTableItemsBLL Com_JetTableItems
		{
			get
			{
				if(iCom_JetTableItemsBll==null)
					iCom_JetTableItemsBll=new Com_JetTableItemsBLL();
				return iCom_JetTableItemsBll;
			}
			set
			{
				iCom_JetTableItemsBll=value;
			}
		}
		#endregion

		#region 93 业务接口
		ICom_JetTableMainBLL iCom_JetTableMainBll;
		public ICom_JetTableMainBLL Com_JetTableMain
		{
			get
			{
				if(iCom_JetTableMainBll==null)
					iCom_JetTableMainBll=new Com_JetTableMainBLL();
				return iCom_JetTableMainBll;
			}
			set
			{
				iCom_JetTableMainBll=value;
			}
		}
		#endregion

		#region 94 业务接口
		ICom_LimitItemsBLL iCom_LimitItemsBll;
		public ICom_LimitItemsBLL Com_LimitItems
		{
			get
			{
				if(iCom_LimitItemsBll==null)
					iCom_LimitItemsBll=new Com_LimitItemsBLL();
				return iCom_LimitItemsBll;
			}
			set
			{
				iCom_LimitItemsBll=value;
			}
		}
		#endregion

		#region 95 业务接口
		ICom_LimitMainBLL iCom_LimitMainBll;
		public ICom_LimitMainBLL Com_LimitMain
		{
			get
			{
				if(iCom_LimitMainBll==null)
					iCom_LimitMainBll=new Com_LimitMainBLL();
				return iCom_LimitMainBll;
			}
			set
			{
				iCom_LimitMainBll=value;
			}
		}
		#endregion

		#region 96 业务接口
		ICom_MusterSimpleBLL iCom_MusterSimpleBll;
		public ICom_MusterSimpleBLL Com_MusterSimple
		{
			get
			{
				if(iCom_MusterSimpleBll==null)
					iCom_MusterSimpleBll=new Com_MusterSimpleBLL();
				return iCom_MusterSimpleBll;
			}
			set
			{
				iCom_MusterSimpleBll=value;
			}
		}
		#endregion

		#region 97 业务接口
		ICom_MusterSimpleFieldsBLL iCom_MusterSimpleFieldsBll;
		public ICom_MusterSimpleFieldsBLL Com_MusterSimpleFields
		{
			get
			{
				if(iCom_MusterSimpleFieldsBll==null)
					iCom_MusterSimpleFieldsBll=new Com_MusterSimpleFieldsBLL();
				return iCom_MusterSimpleFieldsBll;
			}
			set
			{
				iCom_MusterSimpleFieldsBll=value;
			}
		}
		#endregion

		#region 98 业务接口
		ICom_RelationBodyBLL iCom_RelationBodyBll;
		public ICom_RelationBodyBLL Com_RelationBody
		{
			get
			{
				if(iCom_RelationBodyBll==null)
					iCom_RelationBodyBll=new Com_RelationBodyBLL();
				return iCom_RelationBodyBll;
			}
			set
			{
				iCom_RelationBodyBll=value;
			}
		}
		#endregion

		#region 99 业务接口
		ICom_RelationMainBLL iCom_RelationMainBll;
		public ICom_RelationMainBLL Com_RelationMain
		{
			get
			{
				if(iCom_RelationMainBll==null)
					iCom_RelationMainBll=new Com_RelationMainBLL();
				return iCom_RelationMainBll;
			}
			set
			{
				iCom_RelationMainBll=value;
			}
		}
		#endregion

		#region 100 业务接口
		ICom_SortItemsBLL iCom_SortItemsBll;
		public ICom_SortItemsBLL Com_SortItems
		{
			get
			{
				if(iCom_SortItemsBll==null)
					iCom_SortItemsBll=new Com_SortItemsBLL();
				return iCom_SortItemsBll;
			}
			set
			{
				iCom_SortItemsBll=value;
			}
		}
		#endregion

		#region 101 业务接口
		ICom_SortMainBLL iCom_SortMainBll;
		public ICom_SortMainBLL Com_SortMain
		{
			get
			{
				if(iCom_SortMainBll==null)
					iCom_SortMainBll=new Com_SortMainBLL();
				return iCom_SortMainBll;
			}
			set
			{
				iCom_SortMainBll=value;
			}
		}
		#endregion

		#region 102 业务接口
		ICom_StatAnalysisItemsBLL iCom_StatAnalysisItemsBll;
		public ICom_StatAnalysisItemsBLL Com_StatAnalysisItems
		{
			get
			{
				if(iCom_StatAnalysisItemsBll==null)
					iCom_StatAnalysisItemsBll=new Com_StatAnalysisItemsBLL();
				return iCom_StatAnalysisItemsBll;
			}
			set
			{
				iCom_StatAnalysisItemsBll=value;
			}
		}
		#endregion

		#region 103 业务接口
		ICom_StatAnalysisMainBLL iCom_StatAnalysisMainBll;
		public ICom_StatAnalysisMainBLL Com_StatAnalysisMain
		{
			get
			{
				if(iCom_StatAnalysisMainBll==null)
					iCom_StatAnalysisMainBll=new Com_StatAnalysisMainBLL();
				return iCom_StatAnalysisMainBll;
			}
			set
			{
				iCom_StatAnalysisMainBll=value;
			}
		}
		#endregion

		#region 104 业务接口
		ICom_StatLimitColumnsBLL iCom_StatLimitColumnsBll;
		public ICom_StatLimitColumnsBLL Com_StatLimitColumns
		{
			get
			{
				if(iCom_StatLimitColumnsBll==null)
					iCom_StatLimitColumnsBll=new Com_StatLimitColumnsBLL();
				return iCom_StatLimitColumnsBll;
			}
			set
			{
				iCom_StatLimitColumnsBll=value;
			}
		}
		#endregion

		#region 105 业务接口
		ICom_StatLimitMainBLL iCom_StatLimitMainBll;
		public ICom_StatLimitMainBLL Com_StatLimitMain
		{
			get
			{
				if(iCom_StatLimitMainBll==null)
					iCom_StatLimitMainBll=new Com_StatLimitMainBLL();
				return iCom_StatLimitMainBll;
			}
			set
			{
				iCom_StatLimitMainBll=value;
			}
		}
		#endregion

		#region 106 业务接口
		ICom_StatLimitRowsBLL iCom_StatLimitRowsBll;
		public ICom_StatLimitRowsBLL Com_StatLimitRows
		{
			get
			{
				if(iCom_StatLimitRowsBll==null)
					iCom_StatLimitRowsBll=new Com_StatLimitRowsBLL();
				return iCom_StatLimitRowsBll;
			}
			set
			{
				iCom_StatLimitRowsBll=value;
			}
		}
		#endregion

		#region 107 业务接口
		IG01BLL iG01Bll;
		public IG01BLL G01
		{
			get
			{
				if(iG01Bll==null)
					iG01Bll=new G01BLL();
				return iG01Bll;
			}
			set
			{
				iG01Bll=value;
			}
		}
		#endregion

		#region 108 业务接口
		IHR_MusterFieldsBLL iHR_MusterFieldsBll;
		public IHR_MusterFieldsBLL HR_MusterFields
		{
			get
			{
				if(iHR_MusterFieldsBll==null)
					iHR_MusterFieldsBll=new HR_MusterFieldsBLL();
				return iHR_MusterFieldsBll;
			}
			set
			{
				iHR_MusterFieldsBll=value;
			}
		}
		#endregion

		#region 109 业务接口
		IHR_MusterMainBLL iHR_MusterMainBll;
		public IHR_MusterMainBLL HR_MusterMain
		{
			get
			{
				if(iHR_MusterMainBll==null)
					iHR_MusterMainBll=new HR_MusterMainBLL();
				return iHR_MusterMainBll;
			}
			set
			{
				iHR_MusterMainBll=value;
			}
		}
		#endregion

		#region 110 业务接口
		IOP_ExcelForm_ArgsBLL iOP_ExcelForm_ArgsBll;
		public IOP_ExcelForm_ArgsBLL OP_ExcelForm_Args
		{
			get
			{
				if(iOP_ExcelForm_ArgsBll==null)
					iOP_ExcelForm_ArgsBll=new OP_ExcelForm_ArgsBLL();
				return iOP_ExcelForm_ArgsBll;
			}
			set
			{
				iOP_ExcelForm_ArgsBll=value;
			}
		}
		#endregion

		#region 111 业务接口
		IOP_ExcelForm_CatalogBLL iOP_ExcelForm_CatalogBll;
		public IOP_ExcelForm_CatalogBLL OP_ExcelForm_Catalog
		{
			get
			{
				if(iOP_ExcelForm_CatalogBll==null)
					iOP_ExcelForm_CatalogBll=new OP_ExcelForm_CatalogBLL();
				return iOP_ExcelForm_CatalogBll;
			}
			set
			{
				iOP_ExcelForm_CatalogBll=value;
			}
		}
		#endregion

		#region 112 业务接口
		IOP_ExcelForm_CellBLL iOP_ExcelForm_CellBll;
		public IOP_ExcelForm_CellBLL OP_ExcelForm_Cell
		{
			get
			{
				if(iOP_ExcelForm_CellBll==null)
					iOP_ExcelForm_CellBll=new OP_ExcelForm_CellBLL();
				return iOP_ExcelForm_CellBll;
			}
			set
			{
				iOP_ExcelForm_CellBll=value;
			}
		}
		#endregion

		#region 113 业务接口
		IOP_ExcelForm_ColBLL iOP_ExcelForm_ColBll;
		public IOP_ExcelForm_ColBLL OP_ExcelForm_Col
		{
			get
			{
				if(iOP_ExcelForm_ColBll==null)
					iOP_ExcelForm_ColBll=new OP_ExcelForm_ColBLL();
				return iOP_ExcelForm_ColBll;
			}
			set
			{
				iOP_ExcelForm_ColBll=value;
			}
		}
		#endregion

		#region 114 业务接口
		IOP_ExcelForm_DataSourceBLL iOP_ExcelForm_DataSourceBll;
		public IOP_ExcelForm_DataSourceBLL OP_ExcelForm_DataSource
		{
			get
			{
				if(iOP_ExcelForm_DataSourceBll==null)
					iOP_ExcelForm_DataSourceBll=new OP_ExcelForm_DataSourceBLL();
				return iOP_ExcelForm_DataSourceBll;
			}
			set
			{
				iOP_ExcelForm_DataSourceBll=value;
			}
		}
		#endregion

		#region 115 业务接口
		IOP_ExcelForm_DataSourceParseBLL iOP_ExcelForm_DataSourceParseBll;
		public IOP_ExcelForm_DataSourceParseBLL OP_ExcelForm_DataSourceParse
		{
			get
			{
				if(iOP_ExcelForm_DataSourceParseBll==null)
					iOP_ExcelForm_DataSourceParseBll=new OP_ExcelForm_DataSourceParseBLL();
				return iOP_ExcelForm_DataSourceParseBll;
			}
			set
			{
				iOP_ExcelForm_DataSourceParseBll=value;
			}
		}
		#endregion

		#region 116 业务接口
		IOP_ExcelForm_InputBLL iOP_ExcelForm_InputBll;
		public IOP_ExcelForm_InputBLL OP_ExcelForm_Input
		{
			get
			{
				if(iOP_ExcelForm_InputBll==null)
					iOP_ExcelForm_InputBll=new OP_ExcelForm_InputBLL();
				return iOP_ExcelForm_InputBll;
			}
			set
			{
				iOP_ExcelForm_InputBll=value;
			}
		}
		#endregion

		#region 117 业务接口
		IOP_ExcelForm_InputTableBLL iOP_ExcelForm_InputTableBll;
		public IOP_ExcelForm_InputTableBLL OP_ExcelForm_InputTable
		{
			get
			{
				if(iOP_ExcelForm_InputTableBll==null)
					iOP_ExcelForm_InputTableBll=new OP_ExcelForm_InputTableBLL();
				return iOP_ExcelForm_InputTableBll;
			}
			set
			{
				iOP_ExcelForm_InputTableBll=value;
			}
		}
		#endregion

		#region 118 业务接口
		IOP_ExcelForm_InputTableFieldBLL iOP_ExcelForm_InputTableFieldBll;
		public IOP_ExcelForm_InputTableFieldBLL OP_ExcelForm_InputTableField
		{
			get
			{
				if(iOP_ExcelForm_InputTableFieldBll==null)
					iOP_ExcelForm_InputTableFieldBll=new OP_ExcelForm_InputTableFieldBLL();
				return iOP_ExcelForm_InputTableFieldBll;
			}
			set
			{
				iOP_ExcelForm_InputTableFieldBll=value;
			}
		}
		#endregion

		#region 119 业务接口
		IOP_ExcelForm_MainBLL iOP_ExcelForm_MainBll;
		public IOP_ExcelForm_MainBLL OP_ExcelForm_Main
		{
			get
			{
				if(iOP_ExcelForm_MainBll==null)
					iOP_ExcelForm_MainBll=new OP_ExcelForm_MainBLL();
				return iOP_ExcelForm_MainBll;
			}
			set
			{
				iOP_ExcelForm_MainBll=value;
			}
		}
		#endregion

		#region 120 业务接口
		IOP_ExcelForm_PrivilegeBLL iOP_ExcelForm_PrivilegeBll;
		public IOP_ExcelForm_PrivilegeBLL OP_ExcelForm_Privilege
		{
			get
			{
				if(iOP_ExcelForm_PrivilegeBll==null)
					iOP_ExcelForm_PrivilegeBll=new OP_ExcelForm_PrivilegeBLL();
				return iOP_ExcelForm_PrivilegeBll;
			}
			set
			{
				iOP_ExcelForm_PrivilegeBll=value;
			}
		}
		#endregion

		#region 121 业务接口
		IOP_ExcelForm_RowBLL iOP_ExcelForm_RowBll;
		public IOP_ExcelForm_RowBLL OP_ExcelForm_Row
		{
			get
			{
				if(iOP_ExcelForm_RowBll==null)
					iOP_ExcelForm_RowBll=new OP_ExcelForm_RowBLL();
				return iOP_ExcelForm_RowBll;
			}
			set
			{
				iOP_ExcelForm_RowBll=value;
			}
		}
		#endregion

		#region 122 业务接口
		IOP_ExcelForm_RowColBLL iOP_ExcelForm_RowColBll;
		public IOP_ExcelForm_RowColBLL OP_ExcelForm_RowCol
		{
			get
			{
				if(iOP_ExcelForm_RowColBll==null)
					iOP_ExcelForm_RowColBll=new OP_ExcelForm_RowColBLL();
				return iOP_ExcelForm_RowColBll;
			}
			set
			{
				iOP_ExcelForm_RowColBll=value;
			}
		}
		#endregion

		#region 123 业务接口
		IProject_LogApiBLL iProject_LogApiBll;
		public IProject_LogApiBLL Project_LogApi
		{
			get
			{
				if(iProject_LogApiBll==null)
					iProject_LogApiBll=new Project_LogApiBLL();
				return iProject_LogApiBll;
			}
			set
			{
				iProject_LogApiBll=value;
			}
		}
		#endregion

		#region 124 业务接口
		IRC_DataHintBLL iRC_DataHintBll;
		public IRC_DataHintBLL RC_DataHint
		{
			get
			{
				if(iRC_DataHintBll==null)
					iRC_DataHintBll=new RC_DataHintBLL();
				return iRC_DataHintBll;
			}
			set
			{
				iRC_DataHintBll=value;
			}
		}
		#endregion

		#region 125 业务接口
		IRC_DataHintStateBLL iRC_DataHintStateBll;
		public IRC_DataHintStateBLL RC_DataHintState
		{
			get
			{
				if(iRC_DataHintStateBll==null)
					iRC_DataHintStateBll=new RC_DataHintStateBLL();
				return iRC_DataHintStateBll;
			}
			set
			{
				iRC_DataHintStateBll=value;
			}
		}
		#endregion

		#region 126 业务接口
		IRC_DataLimitBLL iRC_DataLimitBll;
		public IRC_DataLimitBLL RC_DataLimit
		{
			get
			{
				if(iRC_DataLimitBll==null)
					iRC_DataLimitBll=new RC_DataLimitBLL();
				return iRC_DataLimitBll;
			}
			set
			{
				iRC_DataLimitBll=value;
			}
		}
		#endregion

		#region 127 业务接口
		IRC_ImportClientDataWayBLL iRC_ImportClientDataWayBll;
		public IRC_ImportClientDataWayBLL RC_ImportClientDataWay
		{
			get
			{
				if(iRC_ImportClientDataWayBll==null)
					iRC_ImportClientDataWayBll=new RC_ImportClientDataWayBLL();
				return iRC_ImportClientDataWayBll;
			}
			set
			{
				iRC_ImportClientDataWayBll=value;
			}
		}
		#endregion

		#region 128 业务接口
		IRC_InfoScriptBLL iRC_InfoScriptBll;
		public IRC_InfoScriptBLL RC_InfoScript
		{
			get
			{
				if(iRC_InfoScriptBll==null)
					iRC_InfoScriptBll=new RC_InfoScriptBLL();
				return iRC_InfoScriptBll;
			}
			set
			{
				iRC_InfoScriptBll=value;
			}
		}
		#endregion

		#region 129 业务接口
		IRC_InfoScriptOrderBLL iRC_InfoScriptOrderBll;
		public IRC_InfoScriptOrderBLL RC_InfoScriptOrder
		{
			get
			{
				if(iRC_InfoScriptOrderBll==null)
					iRC_InfoScriptOrderBll=new RC_InfoScriptOrderBLL();
				return iRC_InfoScriptOrderBll;
			}
			set
			{
				iRC_InfoScriptOrderBll=value;
			}
		}
		#endregion

		#region 130 业务接口
		IRC_JTMainBLL iRC_JTMainBll;
		public IRC_JTMainBLL RC_JTMain
		{
			get
			{
				if(iRC_JTMainBll==null)
					iRC_JTMainBll=new RC_JTMainBLL();
				return iRC_JTMainBll;
			}
			set
			{
				iRC_JTMainBll=value;
			}
		}
		#endregion

		#region 131 业务接口
		IRC_MusterMainBLL iRC_MusterMainBll;
		public IRC_MusterMainBLL RC_MusterMain
		{
			get
			{
				if(iRC_MusterMainBll==null)
					iRC_MusterMainBll=new RC_MusterMainBLL();
				return iRC_MusterMainBll;
			}
			set
			{
				iRC_MusterMainBll=value;
			}
		}
		#endregion

		#region 132 业务接口
		IRC_PolicyAttachBLL iRC_PolicyAttachBll;
		public IRC_PolicyAttachBLL RC_PolicyAttach
		{
			get
			{
				if(iRC_PolicyAttachBll==null)
					iRC_PolicyAttachBll=new RC_PolicyAttachBLL();
				return iRC_PolicyAttachBll;
			}
			set
			{
				iRC_PolicyAttachBll=value;
			}
		}
		#endregion

		#region 133 业务接口
		IRC_PolicyDetailBLL iRC_PolicyDetailBll;
		public IRC_PolicyDetailBLL RC_PolicyDetail
		{
			get
			{
				if(iRC_PolicyDetailBll==null)
					iRC_PolicyDetailBll=new RC_PolicyDetailBLL();
				return iRC_PolicyDetailBll;
			}
			set
			{
				iRC_PolicyDetailBll=value;
			}
		}
		#endregion

		#region 134 业务接口
		IRC_PolicyGroupBLL iRC_PolicyGroupBll;
		public IRC_PolicyGroupBLL RC_PolicyGroup
		{
			get
			{
				if(iRC_PolicyGroupBll==null)
					iRC_PolicyGroupBll=new RC_PolicyGroupBLL();
				return iRC_PolicyGroupBll;
			}
			set
			{
				iRC_PolicyGroupBll=value;
			}
		}
		#endregion

		#region 135 业务接口
		IRC_SearchContainerResultBLL iRC_SearchContainerResultBll;
		public IRC_SearchContainerResultBLL RC_SearchContainerResult
		{
			get
			{
				if(iRC_SearchContainerResultBll==null)
					iRC_SearchContainerResultBll=new RC_SearchContainerResultBLL();
				return iRC_SearchContainerResultBll;
			}
			set
			{
				iRC_SearchContainerResultBll=value;
			}
		}
		#endregion

		#region 136 业务接口
		IRC_StatMainBLL iRC_StatMainBll;
		public IRC_StatMainBLL RC_StatMain
		{
			get
			{
				if(iRC_StatMainBll==null)
					iRC_StatMainBll=new RC_StatMainBLL();
				return iRC_StatMainBll;
			}
			set
			{
				iRC_StatMainBll=value;
			}
		}
		#endregion

		#region 137 业务接口
		IRC_StatMusterFieldBLL iRC_StatMusterFieldBll;
		public IRC_StatMusterFieldBLL RC_StatMusterField
		{
			get
			{
				if(iRC_StatMusterFieldBll==null)
					iRC_StatMusterFieldBll=new RC_StatMusterFieldBLL();
				return iRC_StatMusterFieldBll;
			}
			set
			{
				iRC_StatMusterFieldBll=value;
			}
		}
		#endregion

		#region 138 业务接口
		ISM_CodeItemsBLL iSM_CodeItemsBll;
		public ISM_CodeItemsBLL SM_CodeItems
		{
			get
			{
				if(iSM_CodeItemsBll==null)
					iSM_CodeItemsBll=new SM_CodeItemsBLL();
				return iSM_CodeItemsBll;
			}
			set
			{
				iSM_CodeItemsBll=value;
			}
		}
		#endregion

		#region 139 业务接口
		ISM_CodeTableBLL iSM_CodeTableBll;
		public ISM_CodeTableBLL SM_CodeTable
		{
			get
			{
				if(iSM_CodeTableBll==null)
					iSM_CodeTableBll=new SM_CodeTableBLL();
				return iSM_CodeTableBll;
			}
			set
			{
				iSM_CodeTableBll=value;
			}
		}
		#endregion

		#region 140 业务接口
		ISM_CodeTableGroupBLL iSM_CodeTableGroupBll;
		public ISM_CodeTableGroupBLL SM_CodeTableGroup
		{
			get
			{
				if(iSM_CodeTableGroupBll==null)
					iSM_CodeTableGroupBll=new SM_CodeTableGroupBLL();
				return iSM_CodeTableGroupBll;
			}
			set
			{
				iSM_CodeTableGroupBll=value;
			}
		}
		#endregion

		#region 141 业务接口
		ISM_ConsoleUIGroupBLL iSM_ConsoleUIGroupBll;
		public ISM_ConsoleUIGroupBLL SM_ConsoleUIGroup
		{
			get
			{
				if(iSM_ConsoleUIGroupBll==null)
					iSM_ConsoleUIGroupBll=new SM_ConsoleUIGroupBLL();
				return iSM_ConsoleUIGroupBll;
			}
			set
			{
				iSM_ConsoleUIGroupBll=value;
			}
		}
		#endregion

		#region 142 业务接口
		ISM_ConsoleUIItemBLL iSM_ConsoleUIItemBll;
		public ISM_ConsoleUIItemBLL SM_ConsoleUIItem
		{
			get
			{
				if(iSM_ConsoleUIItemBll==null)
					iSM_ConsoleUIItemBll=new SM_ConsoleUIItemBLL();
				return iSM_ConsoleUIItemBll;
			}
			set
			{
				iSM_ConsoleUIItemBll=value;
			}
		}
		#endregion

		#region 143 业务接口
		ISM_ConsoleUIWayBLL iSM_ConsoleUIWayBll;
		public ISM_ConsoleUIWayBLL SM_ConsoleUIWay
		{
			get
			{
				if(iSM_ConsoleUIWayBll==null)
					iSM_ConsoleUIWayBll=new SM_ConsoleUIWayBLL();
				return iSM_ConsoleUIWayBll;
			}
			set
			{
				iSM_ConsoleUIWayBll=value;
			}
		}
		#endregion

		#region 144 业务接口
		ISM_ConsoleUIWayRoleBLL iSM_ConsoleUIWayRoleBll;
		public ISM_ConsoleUIWayRoleBLL SM_ConsoleUIWayRole
		{
			get
			{
				if(iSM_ConsoleUIWayRoleBll==null)
					iSM_ConsoleUIWayRoleBll=new SM_ConsoleUIWayRoleBLL();
				return iSM_ConsoleUIWayRoleBll;
			}
			set
			{
				iSM_ConsoleUIWayRoleBll=value;
			}
		}
		#endregion

		#region 145 业务接口
		ISM_DBConnectionBLL iSM_DBConnectionBll;
		public ISM_DBConnectionBLL SM_DBConnection
		{
			get
			{
				if(iSM_DBConnectionBll==null)
					iSM_DBConnectionBll=new SM_DBConnectionBLL();
				return iSM_DBConnectionBll;
			}
			set
			{
				iSM_DBConnectionBll=value;
			}
		}
		#endregion

		#region 146 业务接口
		ISM_GlobalScriptBLL iSM_GlobalScriptBll;
		public ISM_GlobalScriptBLL SM_GlobalScript
		{
			get
			{
				if(iSM_GlobalScriptBll==null)
					iSM_GlobalScriptBll=new SM_GlobalScriptBLL();
				return iSM_GlobalScriptBll;
			}
			set
			{
				iSM_GlobalScriptBll=value;
			}
		}
		#endregion

		#region 147 业务接口
		ISM_IdentityBLL iSM_IdentityBll;
		public ISM_IdentityBLL SM_Identity
		{
			get
			{
				if(iSM_IdentityBll==null)
					iSM_IdentityBll=new SM_IdentityBLL();
				return iSM_IdentityBll;
			}
			set
			{
				iSM_IdentityBll=value;
			}
		}
		#endregion

		#region 148 业务接口
		ISM_LogBLL iSM_LogBll;
		public ISM_LogBLL SM_Log
		{
			get
			{
				if(iSM_LogBll==null)
					iSM_LogBll=new SM_LogBLL();
				return iSM_LogBll;
			}
			set
			{
				iSM_LogBll=value;
			}
		}
		#endregion

		#region 149 业务接口
		ISM_LogCycleTimerBLL iSM_LogCycleTimerBll;
		public ISM_LogCycleTimerBLL SM_LogCycleTimer
		{
			get
			{
				if(iSM_LogCycleTimerBll==null)
					iSM_LogCycleTimerBll=new SM_LogCycleTimerBLL();
				return iSM_LogCycleTimerBll;
			}
			set
			{
				iSM_LogCycleTimerBll=value;
			}
		}
		#endregion

		#region 150 业务接口
		ISM_LogDevelopBLL iSM_LogDevelopBll;
		public ISM_LogDevelopBLL SM_LogDevelop
		{
			get
			{
				if(iSM_LogDevelopBll==null)
					iSM_LogDevelopBll=new SM_LogDevelopBLL();
				return iSM_LogDevelopBll;
			}
			set
			{
				iSM_LogDevelopBll=value;
			}
		}
		#endregion

		#region 151 业务接口
		ISM_LogSystemBLL iSM_LogSystemBll;
		public ISM_LogSystemBLL SM_LogSystem
		{
			get
			{
				if(iSM_LogSystemBll==null)
					iSM_LogSystemBll=new SM_LogSystemBLL();
				return iSM_LogSystemBll;
			}
			set
			{
				iSM_LogSystemBll=value;
			}
		}
		#endregion

		#region 152 业务接口
		ISM_PersonClassBLL iSM_PersonClassBll;
		public ISM_PersonClassBLL SM_PersonClass
		{
			get
			{
				if(iSM_PersonClassBll==null)
					iSM_PersonClassBll=new SM_PersonClassBLL();
				return iSM_PersonClassBll;
			}
			set
			{
				iSM_PersonClassBll=value;
			}
		}
		#endregion

		#region 153 业务接口
		ISM_PluginBLL iSM_PluginBll;
		public ISM_PluginBLL SM_Plugin
		{
			get
			{
				if(iSM_PluginBll==null)
					iSM_PluginBll=new SM_PluginBLL();
				return iSM_PluginBll;
			}
			set
			{
				iSM_PluginBll=value;
			}
		}
		#endregion

		#region 154 业务接口
		ISM_Prototype_SimpleBLL iSM_Prototype_SimpleBll;
		public ISM_Prototype_SimpleBLL SM_Prototype_Simple
		{
			get
			{
				if(iSM_Prototype_SimpleBll==null)
					iSM_Prototype_SimpleBll=new SM_Prototype_SimpleBLL();
				return iSM_Prototype_SimpleBll;
			}
			set
			{
				iSM_Prototype_SimpleBll=value;
			}
		}
		#endregion

		#region 155 业务接口
		ISM_PYBLL iSM_PYBll;
		public ISM_PYBLL SM_PY
		{
			get
			{
				if(iSM_PYBll==null)
					iSM_PYBll=new SM_PYBLL();
				return iSM_PYBll;
			}
			set
			{
				iSM_PYBll=value;
			}
		}
		#endregion

		#region 156 业务接口
		ISM_SchedulerBLL iSM_SchedulerBll;
		public ISM_SchedulerBLL SM_Scheduler
		{
			get
			{
				if(iSM_SchedulerBll==null)
					iSM_SchedulerBll=new SM_SchedulerBLL();
				return iSM_SchedulerBll;
			}
			set
			{
				iSM_SchedulerBll=value;
			}
		}
		#endregion

		#region 157 业务接口
		ISM_SchedulerNotifyBLL iSM_SchedulerNotifyBll;
		public ISM_SchedulerNotifyBLL SM_SchedulerNotify
		{
			get
			{
				if(iSM_SchedulerNotifyBll==null)
					iSM_SchedulerNotifyBll=new SM_SchedulerNotifyBLL();
				return iSM_SchedulerNotifyBll;
			}
			set
			{
				iSM_SchedulerNotifyBll=value;
			}
		}
		#endregion

		#region 158 业务接口
		ISM_SchedulerPlanBLL iSM_SchedulerPlanBll;
		public ISM_SchedulerPlanBLL SM_SchedulerPlan
		{
			get
			{
				if(iSM_SchedulerPlanBll==null)
					iSM_SchedulerPlanBll=new SM_SchedulerPlanBLL();
				return iSM_SchedulerPlanBll;
			}
			set
			{
				iSM_SchedulerPlanBll=value;
			}
		}
		#endregion

		#region 159 业务接口
		ISM_SchedulerRunLogBLL iSM_SchedulerRunLogBll;
		public ISM_SchedulerRunLogBLL SM_SchedulerRunLog
		{
			get
			{
				if(iSM_SchedulerRunLogBll==null)
					iSM_SchedulerRunLogBll=new SM_SchedulerRunLogBLL();
				return iSM_SchedulerRunLogBll;
			}
			set
			{
				iSM_SchedulerRunLogBll=value;
			}
		}
		#endregion

		#region 160 业务接口
		ISM_SchedulerTaskBLL iSM_SchedulerTaskBll;
		public ISM_SchedulerTaskBLL SM_SchedulerTask
		{
			get
			{
				if(iSM_SchedulerTaskBll==null)
					iSM_SchedulerTaskBll=new SM_SchedulerTaskBLL();
				return iSM_SchedulerTaskBll;
			}
			set
			{
				iSM_SchedulerTaskBll=value;
			}
		}
		#endregion

		#region 161 业务接口
		ISM_SequenceManageBLL iSM_SequenceManageBll;
		public ISM_SequenceManageBLL SM_SequenceManage
		{
			get
			{
				if(iSM_SequenceManageBll==null)
					iSM_SequenceManageBll=new SM_SequenceManageBLL();
				return iSM_SequenceManageBll;
			}
			set
			{
				iSM_SequenceManageBll=value;
			}
		}
		#endregion

		#region 162 业务接口
		ISM_SetDBBLL iSM_SetDBBll;
		public ISM_SetDBBLL SM_SetDB
		{
			get
			{
				if(iSM_SetDBBll==null)
					iSM_SetDBBll=new SM_SetDBBLL();
				return iSM_SetDBBll;
			}
			set
			{
				iSM_SetDBBll=value;
			}
		}
		#endregion

		#region 163 业务接口
		ISM_SetItemCalcBLL iSM_SetItemCalcBll;
		public ISM_SetItemCalcBLL SM_SetItemCalc
		{
			get
			{
				if(iSM_SetItemCalcBll==null)
					iSM_SetItemCalcBll=new SM_SetItemCalcBLL();
				return iSM_SetItemCalcBll;
			}
			set
			{
				iSM_SetItemCalcBll=value;
			}
		}
		#endregion

		#region 164 业务接口
		ISM_SetItemsBLL iSM_SetItemsBll;
		public ISM_SetItemsBLL SM_SetItems
		{
			get
			{
				if(iSM_SetItemsBll==null)
					iSM_SetItemsBll=new SM_SetItemsBLL();
				return iSM_SetItemsBll;
			}
			set
			{
				iSM_SetItemsBll=value;
			}
		}
		#endregion

		#region 165 业务接口
		ISM_SetItemUserConfigBLL iSM_SetItemUserConfigBll;
		public ISM_SetItemUserConfigBLL SM_SetItemUserConfig
		{
			get
			{
				if(iSM_SetItemUserConfigBll==null)
					iSM_SetItemUserConfigBll=new SM_SetItemUserConfigBLL();
				return iSM_SetItemUserConfigBll;
			}
			set
			{
				iSM_SetItemUserConfigBll=value;
			}
		}
		#endregion

		#region 166 业务接口
		ISM_SetTableBLL iSM_SetTableBll;
		public ISM_SetTableBLL SM_SetTable
		{
			get
			{
				if(iSM_SetTableBll==null)
					iSM_SetTableBll=new SM_SetTableBLL();
				return iSM_SetTableBll;
			}
			set
			{
				iSM_SetTableBll=value;
			}
		}
		#endregion

		#region 167 业务接口
		ISM_SetTableUserConfigBLL iSM_SetTableUserConfigBll;
		public ISM_SetTableUserConfigBLL SM_SetTableUserConfig
		{
			get
			{
				if(iSM_SetTableUserConfigBll==null)
					iSM_SetTableUserConfigBll=new SM_SetTableUserConfigBLL();
				return iSM_SetTableUserConfigBll;
			}
			set
			{
				iSM_SetTableUserConfigBll=value;
			}
		}
		#endregion

		#region 168 业务接口
		ISM_SetWayUserConfigBLL iSM_SetWayUserConfigBll;
		public ISM_SetWayUserConfigBLL SM_SetWayUserConfig
		{
			get
			{
				if(iSM_SetWayUserConfigBll==null)
					iSM_SetWayUserConfigBll=new SM_SetWayUserConfigBLL();
				return iSM_SetWayUserConfigBll;
			}
			set
			{
				iSM_SetWayUserConfigBll=value;
			}
		}
		#endregion

		#region 169 业务接口
		ISM_SqlTemplet_ArgsBLL iSM_SqlTemplet_ArgsBll;
		public ISM_SqlTemplet_ArgsBLL SM_SqlTemplet_Args
		{
			get
			{
				if(iSM_SqlTemplet_ArgsBll==null)
					iSM_SqlTemplet_ArgsBll=new SM_SqlTemplet_ArgsBLL();
				return iSM_SqlTemplet_ArgsBll;
			}
			set
			{
				iSM_SqlTemplet_ArgsBll=value;
			}
		}
		#endregion

		#region 170 业务接口
		ISM_SqlTemplet_CatalogBLL iSM_SqlTemplet_CatalogBll;
		public ISM_SqlTemplet_CatalogBLL SM_SqlTemplet_Catalog
		{
			get
			{
				if(iSM_SqlTemplet_CatalogBll==null)
					iSM_SqlTemplet_CatalogBll=new SM_SqlTemplet_CatalogBLL();
				return iSM_SqlTemplet_CatalogBll;
			}
			set
			{
				iSM_SqlTemplet_CatalogBll=value;
			}
		}
		#endregion

		#region 171 业务接口
		ISM_SqlTemplet_MainBLL iSM_SqlTemplet_MainBll;
		public ISM_SqlTemplet_MainBLL SM_SqlTemplet_Main
		{
			get
			{
				if(iSM_SqlTemplet_MainBll==null)
					iSM_SqlTemplet_MainBll=new SM_SqlTemplet_MainBLL();
				return iSM_SqlTemplet_MainBll;
			}
			set
			{
				iSM_SqlTemplet_MainBll=value;
			}
		}
		#endregion

		#region 172 业务接口
		ISM_Stamp_UnitBLL iSM_Stamp_UnitBll;
		public ISM_Stamp_UnitBLL SM_Stamp_Unit
		{
			get
			{
				if(iSM_Stamp_UnitBll==null)
					iSM_Stamp_UnitBll=new SM_Stamp_UnitBLL();
				return iSM_Stamp_UnitBll;
			}
			set
			{
				iSM_Stamp_UnitBll=value;
			}
		}
		#endregion

		#region 173 业务接口
		ISM_Stamp_UnitUserBLL iSM_Stamp_UnitUserBll;
		public ISM_Stamp_UnitUserBLL SM_Stamp_UnitUser
		{
			get
			{
				if(iSM_Stamp_UnitUserBll==null)
					iSM_Stamp_UnitUserBll=new SM_Stamp_UnitUserBLL();
				return iSM_Stamp_UnitUserBll;
			}
			set
			{
				iSM_Stamp_UnitUserBll=value;
			}
		}
		#endregion

		#region 174 业务接口
		ISM_SystemKeyValueBLL iSM_SystemKeyValueBll;
		public ISM_SystemKeyValueBLL SM_SystemKeyValue
		{
			get
			{
				if(iSM_SystemKeyValueBll==null)
					iSM_SystemKeyValueBll=new SM_SystemKeyValueBLL();
				return iSM_SystemKeyValueBll;
			}
			set
			{
				iSM_SystemKeyValueBll=value;
			}
		}
		#endregion

		#region 175 业务接口
		ISM_SystemMessageBLL iSM_SystemMessageBll;
		public ISM_SystemMessageBLL SM_SystemMessage
		{
			get
			{
				if(iSM_SystemMessageBll==null)
					iSM_SystemMessageBll=new SM_SystemMessageBLL();
				return iSM_SystemMessageBll;
			}
			set
			{
				iSM_SystemMessageBll=value;
			}
		}
		#endregion

		#region 176 业务接口
		ISM_SystemModuleKeyFileBLL iSM_SystemModuleKeyFileBll;
		public ISM_SystemModuleKeyFileBLL SM_SystemModuleKeyFile
		{
			get
			{
				if(iSM_SystemModuleKeyFileBll==null)
					iSM_SystemModuleKeyFileBll=new SM_SystemModuleKeyFileBLL();
				return iSM_SystemModuleKeyFileBll;
			}
			set
			{
				iSM_SystemModuleKeyFileBll=value;
			}
		}
		#endregion

		#region 177 业务接口
		ISM_SystemModuleKeyValueBLL iSM_SystemModuleKeyValueBll;
		public ISM_SystemModuleKeyValueBLL SM_SystemModuleKeyValue
		{
			get
			{
				if(iSM_SystemModuleKeyValueBll==null)
					iSM_SystemModuleKeyValueBll=new SM_SystemModuleKeyValueBLL();
				return iSM_SystemModuleKeyValueBll;
			}
			set
			{
				iSM_SystemModuleKeyValueBll=value;
			}
		}
		#endregion

		#region 178 业务接口
		ISM_Theme_ConfigV2BLL iSM_Theme_ConfigV2Bll;
		public ISM_Theme_ConfigV2BLL SM_Theme_ConfigV2
		{
			get
			{
				if(iSM_Theme_ConfigV2Bll==null)
					iSM_Theme_ConfigV2Bll=new SM_Theme_ConfigV2BLL();
				return iSM_Theme_ConfigV2Bll;
			}
			set
			{
				iSM_Theme_ConfigV2Bll=value;
			}
		}
		#endregion

		#region 179 业务接口
		ISM_Theme_ConfigV2_FileBLL iSM_Theme_ConfigV2_FileBll;
		public ISM_Theme_ConfigV2_FileBLL SM_Theme_ConfigV2_File
		{
			get
			{
				if(iSM_Theme_ConfigV2_FileBll==null)
					iSM_Theme_ConfigV2_FileBll=new SM_Theme_ConfigV2_FileBLL();
				return iSM_Theme_ConfigV2_FileBll;
			}
			set
			{
				iSM_Theme_ConfigV2_FileBll=value;
			}
		}
		#endregion

		#region 180 业务接口
		ISM_Theme_ConfigV2_RoleBLL iSM_Theme_ConfigV2_RoleBll;
		public ISM_Theme_ConfigV2_RoleBLL SM_Theme_ConfigV2_Role
		{
			get
			{
				if(iSM_Theme_ConfigV2_RoleBll==null)
					iSM_Theme_ConfigV2_RoleBll=new SM_Theme_ConfigV2_RoleBLL();
				return iSM_Theme_ConfigV2_RoleBll;
			}
			set
			{
				iSM_Theme_ConfigV2_RoleBll=value;
			}
		}
		#endregion

		#region 181 业务接口
		ISM_Todo_DataWarnBLL iSM_Todo_DataWarnBll;
		public ISM_Todo_DataWarnBLL SM_Todo_DataWarn
		{
			get
			{
				if(iSM_Todo_DataWarnBll==null)
					iSM_Todo_DataWarnBll=new SM_Todo_DataWarnBLL();
				return iSM_Todo_DataWarnBll;
			}
			set
			{
				iSM_Todo_DataWarnBll=value;
			}
		}
		#endregion

		#region 182 业务接口
		ISM_Todo_NoticeBLL iSM_Todo_NoticeBll;
		public ISM_Todo_NoticeBLL SM_Todo_Notice
		{
			get
			{
				if(iSM_Todo_NoticeBll==null)
					iSM_Todo_NoticeBll=new SM_Todo_NoticeBLL();
				return iSM_Todo_NoticeBll;
			}
			set
			{
				iSM_Todo_NoticeBll=value;
			}
		}
		#endregion

		#region 183 业务接口
		ISM_UserKeyValueBLL iSM_UserKeyValueBll;
		public ISM_UserKeyValueBLL SM_UserKeyValue
		{
			get
			{
				if(iSM_UserKeyValueBll==null)
					iSM_UserKeyValueBll=new SM_UserKeyValueBLL();
				return iSM_UserKeyValueBll;
			}
			set
			{
				iSM_UserKeyValueBll=value;
			}
		}
		#endregion

		#region 184 业务接口
		ISM_UserKeyValueExBLL iSM_UserKeyValueExBll;
		public ISM_UserKeyValueExBLL SM_UserKeyValueEx
		{
			get
			{
				if(iSM_UserKeyValueExBll==null)
					iSM_UserKeyValueExBll=new SM_UserKeyValueExBLL();
				return iSM_UserKeyValueExBll;
			}
			set
			{
				iSM_UserKeyValueExBll=value;
			}
		}
		#endregion

		#region 185 业务接口
		ISM_UserOnlineLoggerBLL iSM_UserOnlineLoggerBll;
		public ISM_UserOnlineLoggerBLL SM_UserOnlineLogger
		{
			get
			{
				if(iSM_UserOnlineLoggerBll==null)
					iSM_UserOnlineLoggerBll=new SM_UserOnlineLoggerBLL();
				return iSM_UserOnlineLoggerBll;
			}
			set
			{
				iSM_UserOnlineLoggerBll=value;
			}
		}
		#endregion

		#region 186 业务接口
		ISM_UserRelationBLL iSM_UserRelationBll;
		public ISM_UserRelationBLL SM_UserRelation
		{
			get
			{
				if(iSM_UserRelationBll==null)
					iSM_UserRelationBll=new SM_UserRelationBLL();
				return iSM_UserRelationBll;
			}
			set
			{
				iSM_UserRelationBll=value;
			}
		}
		#endregion

		#region 187 业务接口
		ISM_UserRelationItemBLL iSM_UserRelationItemBll;
		public ISM_UserRelationItemBLL SM_UserRelationItem
		{
			get
			{
				if(iSM_UserRelationItemBll==null)
					iSM_UserRelationItemBll=new SM_UserRelationItemBLL();
				return iSM_UserRelationItemBll;
			}
			set
			{
				iSM_UserRelationItemBll=value;
			}
		}
		#endregion

		#region 188 业务接口
		ISM_VersionBLL iSM_VersionBll;
		public ISM_VersionBLL SM_Version
		{
			get
			{
				if(iSM_VersionBll==null)
					iSM_VersionBll=new SM_VersionBLL();
				return iSM_VersionBll;
			}
			set
			{
				iSM_VersionBll=value;
			}
		}
		#endregion

		#region 189 业务接口
		ISM_Weixin_SystemConfigBLL iSM_Weixin_SystemConfigBll;
		public ISM_Weixin_SystemConfigBLL SM_Weixin_SystemConfig
		{
			get
			{
				if(iSM_Weixin_SystemConfigBll==null)
					iSM_Weixin_SystemConfigBll=new SM_Weixin_SystemConfigBLL();
				return iSM_Weixin_SystemConfigBll;
			}
			set
			{
				iSM_Weixin_SystemConfigBll=value;
			}
		}
		#endregion

		#region 190 业务接口
		ISM_WidgetHomepage_MainBLL iSM_WidgetHomepage_MainBll;
		public ISM_WidgetHomepage_MainBLL SM_WidgetHomepage_Main
		{
			get
			{
				if(iSM_WidgetHomepage_MainBll==null)
					iSM_WidgetHomepage_MainBll=new SM_WidgetHomepage_MainBLL();
				return iSM_WidgetHomepage_MainBll;
			}
			set
			{
				iSM_WidgetHomepage_MainBll=value;
			}
		}
		#endregion

		#region 191 业务接口
		ISM_WidgetHomepage_UserConfigBLL iSM_WidgetHomepage_UserConfigBll;
		public ISM_WidgetHomepage_UserConfigBLL SM_WidgetHomepage_UserConfig
		{
			get
			{
				if(iSM_WidgetHomepage_UserConfigBll==null)
					iSM_WidgetHomepage_UserConfigBll=new SM_WidgetHomepage_UserConfigBLL();
				return iSM_WidgetHomepage_UserConfigBll;
			}
			set
			{
				iSM_WidgetHomepage_UserConfigBll=value;
			}
		}
		#endregion

		#region 192 业务接口
		ISM_WidgetModule_ArgsBLL iSM_WidgetModule_ArgsBll;
		public ISM_WidgetModule_ArgsBLL SM_WidgetModule_Args
		{
			get
			{
				if(iSM_WidgetModule_ArgsBll==null)
					iSM_WidgetModule_ArgsBll=new SM_WidgetModule_ArgsBLL();
				return iSM_WidgetModule_ArgsBll;
			}
			set
			{
				iSM_WidgetModule_ArgsBll=value;
			}
		}
		#endregion

		#region 193 业务接口
		ISM_WidgetModule_CatalogBLL iSM_WidgetModule_CatalogBll;
		public ISM_WidgetModule_CatalogBLL SM_WidgetModule_Catalog
		{
			get
			{
				if(iSM_WidgetModule_CatalogBll==null)
					iSM_WidgetModule_CatalogBll=new SM_WidgetModule_CatalogBLL();
				return iSM_WidgetModule_CatalogBll;
			}
			set
			{
				iSM_WidgetModule_CatalogBll=value;
			}
		}
		#endregion

		#region 194 业务接口
		ISM_WidgetModule_FilesBLL iSM_WidgetModule_FilesBll;
		public ISM_WidgetModule_FilesBLL SM_WidgetModule_Files
		{
			get
			{
				if(iSM_WidgetModule_FilesBll==null)
					iSM_WidgetModule_FilesBll=new SM_WidgetModule_FilesBLL();
				return iSM_WidgetModule_FilesBll;
			}
			set
			{
				iSM_WidgetModule_FilesBll=value;
			}
		}
		#endregion

		#region 195 业务接口
		ISM_WidgetModule_MainBLL iSM_WidgetModule_MainBll;
		public ISM_WidgetModule_MainBLL SM_WidgetModule_Main
		{
			get
			{
				if(iSM_WidgetModule_MainBll==null)
					iSM_WidgetModule_MainBll=new SM_WidgetModule_MainBLL();
				return iSM_WidgetModule_MainBll;
			}
			set
			{
				iSM_WidgetModule_MainBll=value;
			}
		}
		#endregion

		#region 196 业务接口
		ISM_WidgetModule_ObjectConfigBLL iSM_WidgetModule_ObjectConfigBll;
		public ISM_WidgetModule_ObjectConfigBLL SM_WidgetModule_ObjectConfig
		{
			get
			{
				if(iSM_WidgetModule_ObjectConfigBll==null)
					iSM_WidgetModule_ObjectConfigBll=new SM_WidgetModule_ObjectConfigBLL();
				return iSM_WidgetModule_ObjectConfigBll;
			}
			set
			{
				iSM_WidgetModule_ObjectConfigBll=value;
			}
		}
		#endregion

		#region 197 业务接口
		ISM_WidgetModule_ToolBLL iSM_WidgetModule_ToolBll;
		public ISM_WidgetModule_ToolBLL SM_WidgetModule_Tool
		{
			get
			{
				if(iSM_WidgetModule_ToolBll==null)
					iSM_WidgetModule_ToolBll=new SM_WidgetModule_ToolBLL();
				return iSM_WidgetModule_ToolBll;
			}
			set
			{
				iSM_WidgetModule_ToolBll=value;
			}
		}
		#endregion

		#region 198 业务接口
		ISM_WidgetModule_ToolBarBLL iSM_WidgetModule_ToolBarBll;
		public ISM_WidgetModule_ToolBarBLL SM_WidgetModule_ToolBar
		{
			get
			{
				if(iSM_WidgetModule_ToolBarBll==null)
					iSM_WidgetModule_ToolBarBll=new SM_WidgetModule_ToolBarBLL();
				return iSM_WidgetModule_ToolBarBll;
			}
			set
			{
				iSM_WidgetModule_ToolBarBll=value;
			}
		}
		#endregion

		#region 199 业务接口
		IsysdiagramsBLL isysdiagramsBll;
		public IsysdiagramsBLL sysdiagrams
		{
			get
			{
				if(isysdiagramsBll==null)
					isysdiagramsBll=new sysdiagramsBLL();
				return isysdiagramsBll;
			}
			set
			{
				isysdiagramsBll=value;
			}
		}
		#endregion

		#region 200 业务接口
		IT_AreaInfoBLL iT_AreaInfoBll;
		public IT_AreaInfoBLL T_AreaInfo
		{
			get
			{
				if(iT_AreaInfoBll==null)
					iT_AreaInfoBll=new T_AreaInfoBLL();
				return iT_AreaInfoBll;
			}
			set
			{
				iT_AreaInfoBll=value;
			}
		}
		#endregion

		#region 201 业务接口
		IT_AreaPermissRelationBLL iT_AreaPermissRelationBll;
		public IT_AreaPermissRelationBLL T_AreaPermissRelation
		{
			get
			{
				if(iT_AreaPermissRelationBll==null)
					iT_AreaPermissRelationBll=new T_AreaPermissRelationBLL();
				return iT_AreaPermissRelationBll;
			}
			set
			{
				iT_AreaPermissRelationBll=value;
			}
		}
		#endregion

		#region 202 业务接口
		IT_AskManagerBLL iT_AskManagerBll;
		public IT_AskManagerBLL T_AskManager
		{
			get
			{
				if(iT_AskManagerBll==null)
					iT_AskManagerBll=new T_AskManagerBLL();
				return iT_AskManagerBll;
			}
			set
			{
				iT_AskManagerBll=value;
			}
		}
		#endregion

		#region 203 业务接口
		IT_B01PermissRelationBLL iT_B01PermissRelationBll;
		public IT_B01PermissRelationBLL T_B01PermissRelation
		{
			get
			{
				if(iT_B01PermissRelationBll==null)
					iT_B01PermissRelationBll=new T_B01PermissRelationBLL();
				return iT_B01PermissRelationBll;
			}
			set
			{
				iT_B01PermissRelationBll=value;
			}
		}
		#endregion

		#region 204 业务接口
		IT_ComplaintsBLL iT_ComplaintsBll;
		public IT_ComplaintsBLL T_Complaints
		{
			get
			{
				if(iT_ComplaintsBll==null)
					iT_ComplaintsBll=new T_ComplaintsBLL();
				return iT_ComplaintsBll;
			}
			set
			{
				iT_ComplaintsBll=value;
			}
		}
		#endregion

		#region 205 业务接口
		IT_CompProInfoBLL iT_CompProInfoBll;
		public IT_CompProInfoBLL T_CompProInfo
		{
			get
			{
				if(iT_CompProInfoBll==null)
					iT_CompProInfoBll=new T_CompProInfoBLL();
				return iT_CompProInfoBll;
			}
			set
			{
				iT_CompProInfoBll=value;
			}
		}
		#endregion

		#region 206 业务接口
		IT_DocFolderPermissRelationBLL iT_DocFolderPermissRelationBll;
		public IT_DocFolderPermissRelationBLL T_DocFolderPermissRelation
		{
			get
			{
				if(iT_DocFolderPermissRelationBll==null)
					iT_DocFolderPermissRelationBll=new T_DocFolderPermissRelationBLL();
				return iT_DocFolderPermissRelationBll;
			}
			set
			{
				iT_DocFolderPermissRelationBll=value;
			}
		}
		#endregion

		#region 207 业务接口
		IT_DocumentFolderBLL iT_DocumentFolderBll;
		public IT_DocumentFolderBLL T_DocumentFolder
		{
			get
			{
				if(iT_DocumentFolderBll==null)
					iT_DocumentFolderBll=new T_DocumentFolderBLL();
				return iT_DocumentFolderBll;
			}
			set
			{
				iT_DocumentFolderBll=value;
			}
		}
		#endregion

		#region 208 业务接口
		IT_DocumentFolderRelationBLL iT_DocumentFolderRelationBll;
		public IT_DocumentFolderRelationBLL T_DocumentFolderRelation
		{
			get
			{
				if(iT_DocumentFolderRelationBll==null)
					iT_DocumentFolderRelationBll=new T_DocumentFolderRelationBLL();
				return iT_DocumentFolderRelationBll;
			}
			set
			{
				iT_DocumentFolderRelationBll=value;
			}
		}
		#endregion

		#region 209 业务接口
		IT_DocumentInfoBLL iT_DocumentInfoBll;
		public IT_DocumentInfoBLL T_DocumentInfo
		{
			get
			{
				if(iT_DocumentInfoBll==null)
					iT_DocumentInfoBll=new T_DocumentInfoBLL();
				return iT_DocumentInfoBll;
			}
			set
			{
				iT_DocumentInfoBll=value;
			}
		}
		#endregion

		#region 210 业务接口
		IT_DocumentSetTypeBLL iT_DocumentSetTypeBll;
		public IT_DocumentSetTypeBLL T_DocumentSetType
		{
			get
			{
				if(iT_DocumentSetTypeBll==null)
					iT_DocumentSetTypeBll=new T_DocumentSetTypeBLL();
				return iT_DocumentSetTypeBll;
			}
			set
			{
				iT_DocumentSetTypeBll=value;
			}
		}
		#endregion

		#region 211 业务接口
		IT_ElementPermissRelationBLL iT_ElementPermissRelationBll;
		public IT_ElementPermissRelationBLL T_ElementPermissRelation
		{
			get
			{
				if(iT_ElementPermissRelationBll==null)
					iT_ElementPermissRelationBll=new T_ElementPermissRelationBLL();
				return iT_ElementPermissRelationBll;
			}
			set
			{
				iT_ElementPermissRelationBll=value;
			}
		}
		#endregion

		#region 212 业务接口
		IT_EnterDetailBLL iT_EnterDetailBll;
		public IT_EnterDetailBLL T_EnterDetail
		{
			get
			{
				if(iT_EnterDetailBll==null)
					iT_EnterDetailBll=new T_EnterDetailBLL();
				return iT_EnterDetailBll;
			}
			set
			{
				iT_EnterDetailBll=value;
			}
		}
		#endregion

		#region 213 业务接口
		IT_EquipmentBLL iT_EquipmentBll;
		public IT_EquipmentBLL T_Equipment
		{
			get
			{
				if(iT_EquipmentBll==null)
					iT_EquipmentBll=new T_EquipmentBLL();
				return iT_EquipmentBll;
			}
			set
			{
				iT_EquipmentBll=value;
			}
		}
		#endregion

		#region 214 业务接口
		IT_ExceptionLogBLL iT_ExceptionLogBll;
		public IT_ExceptionLogBLL T_ExceptionLog
		{
			get
			{
				if(iT_ExceptionLogBll==null)
					iT_ExceptionLogBll=new T_ExceptionLogBLL();
				return iT_ExceptionLogBll;
			}
			set
			{
				iT_ExceptionLogBll=value;
			}
		}
		#endregion

		#region 215 业务接口
		IT_FilePermissRelationBLL iT_FilePermissRelationBll;
		public IT_FilePermissRelationBLL T_FilePermissRelation
		{
			get
			{
				if(iT_FilePermissRelationBll==null)
					iT_FilePermissRelationBll=new T_FilePermissRelationBLL();
				return iT_FilePermissRelationBll;
			}
			set
			{
				iT_FilePermissRelationBll=value;
			}
		}
		#endregion

		#region 216 业务接口
		IT_FolderPermissRelationBLL iT_FolderPermissRelationBll;
		public IT_FolderPermissRelationBLL T_FolderPermissRelation
		{
			get
			{
				if(iT_FolderPermissRelationBll==null)
					iT_FolderPermissRelationBll=new T_FolderPermissRelationBLL();
				return iT_FolderPermissRelationBll;
			}
			set
			{
				iT_FolderPermissRelationBll=value;
			}
		}
		#endregion

		#region 217 业务接口
		IT_FunctionBLL iT_FunctionBll;
		public IT_FunctionBLL T_Function
		{
			get
			{
				if(iT_FunctionBll==null)
					iT_FunctionBll=new T_FunctionBLL();
				return iT_FunctionBll;
			}
			set
			{
				iT_FunctionBll=value;
			}
		}
		#endregion

		#region 218 业务接口
		IT_ImplementBLL iT_ImplementBll;
		public IT_ImplementBLL T_Implement
		{
			get
			{
				if(iT_ImplementBll==null)
					iT_ImplementBll=new T_ImplementBLL();
				return iT_ImplementBll;
			}
			set
			{
				iT_ImplementBll=value;
			}
		}
		#endregion

		#region 219 业务接口
		IT_ItemCodeBLL iT_ItemCodeBll;
		public IT_ItemCodeBLL T_ItemCode
		{
			get
			{
				if(iT_ItemCodeBll==null)
					iT_ItemCodeBll=new T_ItemCodeBLL();
				return iT_ItemCodeBll;
			}
			set
			{
				iT_ItemCodeBll=value;
			}
		}
		#endregion

		#region 220 业务接口
		IT_ItemCodeMenumBLL iT_ItemCodeMenumBll;
		public IT_ItemCodeMenumBLL T_ItemCodeMenum
		{
			get
			{
				if(iT_ItemCodeMenumBll==null)
					iT_ItemCodeMenumBll=new T_ItemCodeMenumBLL();
				return iT_ItemCodeMenumBll;
			}
			set
			{
				iT_ItemCodeMenumBll=value;
			}
		}
		#endregion

		#region 221 业务接口
		IT_JobResumeRelationBLL iT_JobResumeRelationBll;
		public IT_JobResumeRelationBLL T_JobResumeRelation
		{
			get
			{
				if(iT_JobResumeRelationBll==null)
					iT_JobResumeRelationBll=new T_JobResumeRelationBLL();
				return iT_JobResumeRelationBll;
			}
			set
			{
				iT_JobResumeRelationBll=value;
			}
		}
		#endregion

		#region 222 业务接口
		IT_LimitUserBLL iT_LimitUserBll;
		public IT_LimitUserBLL T_LimitUser
		{
			get
			{
				if(iT_LimitUserBll==null)
					iT_LimitUserBll=new T_LimitUserBLL();
				return iT_LimitUserBll;
			}
			set
			{
				iT_LimitUserBll=value;
			}
		}
		#endregion

		#region 223 业务接口
		IT_LoginBLL iT_LoginBll;
		public IT_LoginBLL T_Login
		{
			get
			{
				if(iT_LoginBll==null)
					iT_LoginBll=new T_LoginBLL();
				return iT_LoginBll;
			}
			set
			{
				iT_LoginBll=value;
			}
		}
		#endregion

		#region 224 业务接口
		IT_LogSetingBLL iT_LogSetingBll;
		public IT_LogSetingBLL T_LogSeting
		{
			get
			{
				if(iT_LogSetingBll==null)
					iT_LogSetingBll=new T_LogSetingBLL();
				return iT_LogSetingBll;
			}
			set
			{
				iT_LogSetingBll=value;
			}
		}
		#endregion

		#region 225 业务接口
		IT_LogSetingDetailBLL iT_LogSetingDetailBll;
		public IT_LogSetingDetailBLL T_LogSetingDetail
		{
			get
			{
				if(iT_LogSetingDetailBll==null)
					iT_LogSetingDetailBll=new T_LogSetingDetailBLL();
				return iT_LogSetingDetailBll;
			}
			set
			{
				iT_LogSetingDetailBll=value;
			}
		}
		#endregion

		#region 226 业务接口
		IT_MessageNoticeBLL iT_MessageNoticeBll;
		public IT_MessageNoticeBLL T_MessageNotice
		{
			get
			{
				if(iT_MessageNoticeBll==null)
					iT_MessageNoticeBll=new T_MessageNoticeBLL();
				return iT_MessageNoticeBll;
			}
			set
			{
				iT_MessageNoticeBll=value;
			}
		}
		#endregion

		#region 227 业务接口
		IT_ModulePermissRelationBLL iT_ModulePermissRelationBll;
		public IT_ModulePermissRelationBLL T_ModulePermissRelation
		{
			get
			{
				if(iT_ModulePermissRelationBll==null)
					iT_ModulePermissRelationBll=new T_ModulePermissRelationBLL();
				return iT_ModulePermissRelationBll;
			}
			set
			{
				iT_ModulePermissRelationBll=value;
			}
		}
		#endregion

		#region 228 业务接口
		IT_Org_UserBLL iT_Org_UserBll;
		public IT_Org_UserBLL T_Org_User
		{
			get
			{
				if(iT_Org_UserBll==null)
					iT_Org_UserBll=new T_Org_UserBLL();
				return iT_Org_UserBll;
			}
			set
			{
				iT_Org_UserBll=value;
			}
		}
		#endregion

		#region 229 业务接口
		IT_OrgFolderBLL iT_OrgFolderBll;
		public IT_OrgFolderBLL T_OrgFolder
		{
			get
			{
				if(iT_OrgFolderBll==null)
					iT_OrgFolderBll=new T_OrgFolderBLL();
				return iT_OrgFolderBll;
			}
			set
			{
				iT_OrgFolderBll=value;
			}
		}
		#endregion

		#region 230 业务接口
		IT_OrgUserRelationBLL iT_OrgUserRelationBll;
		public IT_OrgUserRelationBLL T_OrgUserRelation
		{
			get
			{
				if(iT_OrgUserRelationBll==null)
					iT_OrgUserRelationBll=new T_OrgUserRelationBLL();
				return iT_OrgUserRelationBll;
			}
			set
			{
				iT_OrgUserRelationBll=value;
			}
		}
		#endregion

		#region 231 业务接口
		IT_PageElementBLL iT_PageElementBll;
		public IT_PageElementBLL T_PageElement
		{
			get
			{
				if(iT_PageElementBll==null)
					iT_PageElementBll=new T_PageElementBLL();
				return iT_PageElementBll;
			}
			set
			{
				iT_PageElementBll=value;
			}
		}
		#endregion

		#region 232 业务接口
		IT_PageFileBLL iT_PageFileBll;
		public IT_PageFileBLL T_PageFile
		{
			get
			{
				if(iT_PageFileBll==null)
					iT_PageFileBll=new T_PageFileBLL();
				return iT_PageFileBll;
			}
			set
			{
				iT_PageFileBll=value;
			}
		}
		#endregion

		#region 233 业务接口
		IT_PageFolderBLL iT_PageFolderBll;
		public IT_PageFolderBLL T_PageFolder
		{
			get
			{
				if(iT_PageFolderBll==null)
					iT_PageFolderBll=new T_PageFolderBLL();
				return iT_PageFolderBll;
			}
			set
			{
				iT_PageFolderBll=value;
			}
		}
		#endregion

		#region 234 业务接口
		IT_PayAccountBLL iT_PayAccountBll;
		public IT_PayAccountBLL T_PayAccount
		{
			get
			{
				if(iT_PayAccountBll==null)
					iT_PayAccountBll=new T_PayAccountBLL();
				return iT_PayAccountBll;
			}
			set
			{
				iT_PayAccountBll=value;
			}
		}
		#endregion

		#region 235 业务接口
		IT_PerFuncRelationBLL iT_PerFuncRelationBll;
		public IT_PerFuncRelationBLL T_PerFuncRelation
		{
			get
			{
				if(iT_PerFuncRelationBll==null)
					iT_PerFuncRelationBll=new T_PerFuncRelationBLL();
				return iT_PerFuncRelationBll;
			}
			set
			{
				iT_PerFuncRelationBll=value;
			}
		}
		#endregion

		#region 236 业务接口
		IT_PermissConfigBLL iT_PermissConfigBll;
		public IT_PermissConfigBLL T_PermissConfig
		{
			get
			{
				if(iT_PermissConfigBll==null)
					iT_PermissConfigBll=new T_PermissConfigBLL();
				return iT_PermissConfigBll;
			}
			set
			{
				iT_PermissConfigBll=value;
			}
		}
		#endregion

		#region 237 业务接口
		IT_PermissionsBLL iT_PermissionsBll;
		public IT_PermissionsBLL T_Permissions
		{
			get
			{
				if(iT_PermissionsBll==null)
					iT_PermissionsBll=new T_PermissionsBLL();
				return iT_PermissionsBll;
			}
			set
			{
				iT_PermissionsBll=value;
			}
		}
		#endregion

		#region 238 业务接口
		IT_RoleBLL iT_RoleBll;
		public IT_RoleBLL T_Role
		{
			get
			{
				if(iT_RoleBll==null)
					iT_RoleBll=new T_RoleBLL();
				return iT_RoleBll;
			}
			set
			{
				iT_RoleBll=value;
			}
		}
		#endregion

		#region 239 业务接口
		IT_RoleGroupRelationBLL iT_RoleGroupRelationBll;
		public IT_RoleGroupRelationBLL T_RoleGroupRelation
		{
			get
			{
				if(iT_RoleGroupRelationBll==null)
					iT_RoleGroupRelationBll=new T_RoleGroupRelationBLL();
				return iT_RoleGroupRelationBll;
			}
			set
			{
				iT_RoleGroupRelationBll=value;
			}
		}
		#endregion

		#region 240 业务接口
		IT_RolePermissRelationBLL iT_RolePermissRelationBll;
		public IT_RolePermissRelationBLL T_RolePermissRelation
		{
			get
			{
				if(iT_RolePermissRelationBll==null)
					iT_RolePermissRelationBll=new T_RolePermissRelationBLL();
				return iT_RolePermissRelationBll;
			}
			set
			{
				iT_RolePermissRelationBll=value;
			}
		}
		#endregion

		#region 241 业务接口
		IT_SetMainPageBLL iT_SetMainPageBll;
		public IT_SetMainPageBLL T_SetMainPage
		{
			get
			{
				if(iT_SetMainPageBll==null)
					iT_SetMainPageBll=new T_SetMainPageBLL();
				return iT_SetMainPageBll;
			}
			set
			{
				iT_SetMainPageBll=value;
			}
		}
		#endregion

		#region 242 业务接口
		IT_SynchronousBLL iT_SynchronousBll;
		public IT_SynchronousBLL T_Synchronous
		{
			get
			{
				if(iT_SynchronousBll==null)
					iT_SynchronousBll=new T_SynchronousBLL();
				return iT_SynchronousBll;
			}
			set
			{
				iT_SynchronousBll=value;
			}
		}
		#endregion

		#region 243 业务接口
		IT_SysModuleBLL iT_SysModuleBll;
		public IT_SysModuleBLL T_SysModule
		{
			get
			{
				if(iT_SysModuleBll==null)
					iT_SysModuleBll=new T_SysModuleBLL();
				return iT_SysModuleBll;
			}
			set
			{
				iT_SysModuleBll=value;
			}
		}
		#endregion

		#region 244 业务接口
		IT_TableBLL iT_TableBll;
		public IT_TableBLL T_Table
		{
			get
			{
				if(iT_TableBll==null)
					iT_TableBll=new T_TableBLL();
				return iT_TableBll;
			}
			set
			{
				iT_TableBll=value;
			}
		}
		#endregion

		#region 245 业务接口
		IT_TableFieldBLL iT_TableFieldBll;
		public IT_TableFieldBLL T_TableField
		{
			get
			{
				if(iT_TableFieldBll==null)
					iT_TableFieldBll=new T_TableFieldBLL();
				return iT_TableFieldBll;
			}
			set
			{
				iT_TableFieldBll=value;
			}
		}
		#endregion

		#region 246 业务接口
		IT_TodoListBLL iT_TodoListBll;
		public IT_TodoListBLL T_TodoList
		{
			get
			{
				if(iT_TodoListBll==null)
					iT_TodoListBll=new T_TodoListBLL();
				return iT_TodoListBll;
			}
			set
			{
				iT_TodoListBll=value;
			}
		}
		#endregion

		#region 247 业务接口
		IT_UserBLL iT_UserBll;
		public IT_UserBLL T_User
		{
			get
			{
				if(iT_UserBll==null)
					iT_UserBll=new T_UserBLL();
				return iT_UserBll;
			}
			set
			{
				iT_UserBll=value;
			}
		}
		#endregion

		#region 248 业务接口
		IT_UserGroupBLL iT_UserGroupBll;
		public IT_UserGroupBLL T_UserGroup
		{
			get
			{
				if(iT_UserGroupBll==null)
					iT_UserGroupBll=new T_UserGroupBLL();
				return iT_UserGroupBll;
			}
			set
			{
				iT_UserGroupBll=value;
			}
		}
		#endregion

		#region 249 业务接口
		IT_UserGroupRelationBLL iT_UserGroupRelationBll;
		public IT_UserGroupRelationBLL T_UserGroupRelation
		{
			get
			{
				if(iT_UserGroupRelationBll==null)
					iT_UserGroupRelationBll=new T_UserGroupRelationBLL();
				return iT_UserGroupRelationBll;
			}
			set
			{
				iT_UserGroupRelationBll=value;
			}
		}
		#endregion

		#region 250 业务接口
		IT_UserRoleRelationBLL iT_UserRoleRelationBll;
		public IT_UserRoleRelationBLL T_UserRoleRelation
		{
			get
			{
				if(iT_UserRoleRelationBll==null)
					iT_UserRoleRelationBll=new T_UserRoleRelationBLL();
				return iT_UserRoleRelationBll;
			}
			set
			{
				iT_UserRoleRelationBll=value;
			}
		}
		#endregion

		#region 251 业务接口
		IT_UserUnitRelationBLL iT_UserUnitRelationBll;
		public IT_UserUnitRelationBLL T_UserUnitRelation
		{
			get
			{
				if(iT_UserUnitRelationBll==null)
					iT_UserUnitRelationBll=new T_UserUnitRelationBLL();
				return iT_UserUnitRelationBll;
			}
			set
			{
				iT_UserUnitRelationBll=value;
			}
		}
		#endregion

		#region 252 业务接口
		IT_UseWorkerBLL iT_UseWorkerBll;
		public IT_UseWorkerBLL T_UseWorker
		{
			get
			{
				if(iT_UseWorkerBll==null)
					iT_UseWorkerBll=new T_UseWorkerBLL();
				return iT_UseWorkerBll;
			}
			set
			{
				iT_UseWorkerBll=value;
			}
		}
		#endregion

		#region 253 业务接口
		IV_Auth_Per_00001_System_BPM_StartBLL iV_Auth_Per_00001_System_BPM_StartBll;
		public IV_Auth_Per_00001_System_BPM_StartBLL V_Auth_Per_00001_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_00001_System_BPM_StartBll==null)
					iV_Auth_Per_00001_System_BPM_StartBll=new V_Auth_Per_00001_System_BPM_StartBLL();
				return iV_Auth_Per_00001_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_00001_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 254 业务接口
		IV_Auth_Per_00001_System_Operation_StartBLL iV_Auth_Per_00001_System_Operation_StartBll;
		public IV_Auth_Per_00001_System_Operation_StartBLL V_Auth_Per_00001_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_00001_System_Operation_StartBll==null)
					iV_Auth_Per_00001_System_Operation_StartBll=new V_Auth_Per_00001_System_Operation_StartBLL();
				return iV_Auth_Per_00001_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_00001_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 255 业务接口
		IV_Auth_Per_00001_System_Org_TreeBLL iV_Auth_Per_00001_System_Org_TreeBll;
		public IV_Auth_Per_00001_System_Org_TreeBLL V_Auth_Per_00001_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_00001_System_Org_TreeBll==null)
					iV_Auth_Per_00001_System_Org_TreeBll=new V_Auth_Per_00001_System_Org_TreeBLL();
				return iV_Auth_Per_00001_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_00001_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 256 业务接口
		IV_Auth_Per_00001_System_Person_ReadwriteBLL iV_Auth_Per_00001_System_Person_ReadwriteBll;
		public IV_Auth_Per_00001_System_Person_ReadwriteBLL V_Auth_Per_00001_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_00001_System_Person_ReadwriteBll==null)
					iV_Auth_Per_00001_System_Person_ReadwriteBll=new V_Auth_Per_00001_System_Person_ReadwriteBLL();
				return iV_Auth_Per_00001_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_00001_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 257 业务接口
		IV_Auth_Per_00001_System_PersonClassBLL iV_Auth_Per_00001_System_PersonClassBll;
		public IV_Auth_Per_00001_System_PersonClassBLL V_Auth_Per_00001_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_00001_System_PersonClassBll==null)
					iV_Auth_Per_00001_System_PersonClassBll=new V_Auth_Per_00001_System_PersonClassBLL();
				return iV_Auth_Per_00001_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_00001_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 258 业务接口
		IV_Auth_Per_00002_System_BPM_StartBLL iV_Auth_Per_00002_System_BPM_StartBll;
		public IV_Auth_Per_00002_System_BPM_StartBLL V_Auth_Per_00002_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_00002_System_BPM_StartBll==null)
					iV_Auth_Per_00002_System_BPM_StartBll=new V_Auth_Per_00002_System_BPM_StartBLL();
				return iV_Auth_Per_00002_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_00002_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 259 业务接口
		IV_Auth_Per_00002_System_Operation_StartBLL iV_Auth_Per_00002_System_Operation_StartBll;
		public IV_Auth_Per_00002_System_Operation_StartBLL V_Auth_Per_00002_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_00002_System_Operation_StartBll==null)
					iV_Auth_Per_00002_System_Operation_StartBll=new V_Auth_Per_00002_System_Operation_StartBLL();
				return iV_Auth_Per_00002_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_00002_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 260 业务接口
		IV_Auth_Per_00002_System_Org_TreeBLL iV_Auth_Per_00002_System_Org_TreeBll;
		public IV_Auth_Per_00002_System_Org_TreeBLL V_Auth_Per_00002_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_00002_System_Org_TreeBll==null)
					iV_Auth_Per_00002_System_Org_TreeBll=new V_Auth_Per_00002_System_Org_TreeBLL();
				return iV_Auth_Per_00002_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_00002_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 261 业务接口
		IV_Auth_Per_00002_System_Person_ReadwriteBLL iV_Auth_Per_00002_System_Person_ReadwriteBll;
		public IV_Auth_Per_00002_System_Person_ReadwriteBLL V_Auth_Per_00002_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_00002_System_Person_ReadwriteBll==null)
					iV_Auth_Per_00002_System_Person_ReadwriteBll=new V_Auth_Per_00002_System_Person_ReadwriteBLL();
				return iV_Auth_Per_00002_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_00002_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 262 业务接口
		IV_Auth_Per_00002_System_PersonClassBLL iV_Auth_Per_00002_System_PersonClassBll;
		public IV_Auth_Per_00002_System_PersonClassBLL V_Auth_Per_00002_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_00002_System_PersonClassBll==null)
					iV_Auth_Per_00002_System_PersonClassBll=new V_Auth_Per_00002_System_PersonClassBLL();
				return iV_Auth_Per_00002_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_00002_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 263 业务接口
		IV_Auth_Per_anonymous_System_BPM_StartBLL iV_Auth_Per_anonymous_System_BPM_StartBll;
		public IV_Auth_Per_anonymous_System_BPM_StartBLL V_Auth_Per_anonymous_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_BPM_StartBll==null)
					iV_Auth_Per_anonymous_System_BPM_StartBll=new V_Auth_Per_anonymous_System_BPM_StartBLL();
				return iV_Auth_Per_anonymous_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_anonymous_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 264 业务接口
		IV_Auth_Per_anonymous_System_Operation_StartBLL iV_Auth_Per_anonymous_System_Operation_StartBll;
		public IV_Auth_Per_anonymous_System_Operation_StartBLL V_Auth_Per_anonymous_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_Operation_StartBll==null)
					iV_Auth_Per_anonymous_System_Operation_StartBll=new V_Auth_Per_anonymous_System_Operation_StartBLL();
				return iV_Auth_Per_anonymous_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_anonymous_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 265 业务接口
		IV_Auth_Per_anonymous_System_Org_TreeBLL iV_Auth_Per_anonymous_System_Org_TreeBll;
		public IV_Auth_Per_anonymous_System_Org_TreeBLL V_Auth_Per_anonymous_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_Org_TreeBll==null)
					iV_Auth_Per_anonymous_System_Org_TreeBll=new V_Auth_Per_anonymous_System_Org_TreeBLL();
				return iV_Auth_Per_anonymous_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_anonymous_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 266 业务接口
		IV_Auth_Per_anonymous_System_Person_ReadwriteBLL iV_Auth_Per_anonymous_System_Person_ReadwriteBll;
		public IV_Auth_Per_anonymous_System_Person_ReadwriteBLL V_Auth_Per_anonymous_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_Person_ReadwriteBll==null)
					iV_Auth_Per_anonymous_System_Person_ReadwriteBll=new V_Auth_Per_anonymous_System_Person_ReadwriteBLL();
				return iV_Auth_Per_anonymous_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_anonymous_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 267 业务接口
		IV_Auth_Per_anonymous_System_PersonClassBLL iV_Auth_Per_anonymous_System_PersonClassBll;
		public IV_Auth_Per_anonymous_System_PersonClassBLL V_Auth_Per_anonymous_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_PersonClassBll==null)
					iV_Auth_Per_anonymous_System_PersonClassBll=new V_Auth_Per_anonymous_System_PersonClassBLL();
				return iV_Auth_Per_anonymous_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_anonymous_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 268 业务接口
		IV_Auth_Per_U00000B_System_BPM_StartBLL iV_Auth_Per_U00000B_System_BPM_StartBll;
		public IV_Auth_Per_U00000B_System_BPM_StartBLL V_Auth_Per_U00000B_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_BPM_StartBll==null)
					iV_Auth_Per_U00000B_System_BPM_StartBll=new V_Auth_Per_U00000B_System_BPM_StartBLL();
				return iV_Auth_Per_U00000B_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000B_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 269 业务接口
		IV_Auth_Per_U00000B_System_Operation_StartBLL iV_Auth_Per_U00000B_System_Operation_StartBll;
		public IV_Auth_Per_U00000B_System_Operation_StartBLL V_Auth_Per_U00000B_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_Operation_StartBll==null)
					iV_Auth_Per_U00000B_System_Operation_StartBll=new V_Auth_Per_U00000B_System_Operation_StartBLL();
				return iV_Auth_Per_U00000B_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000B_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 270 业务接口
		IV_Auth_Per_U00000B_System_Org_TreeBLL iV_Auth_Per_U00000B_System_Org_TreeBll;
		public IV_Auth_Per_U00000B_System_Org_TreeBLL V_Auth_Per_U00000B_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_Org_TreeBll==null)
					iV_Auth_Per_U00000B_System_Org_TreeBll=new V_Auth_Per_U00000B_System_Org_TreeBLL();
				return iV_Auth_Per_U00000B_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000B_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 271 业务接口
		IV_Auth_Per_U00000B_System_Person_ReadwriteBLL iV_Auth_Per_U00000B_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000B_System_Person_ReadwriteBLL V_Auth_Per_U00000B_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000B_System_Person_ReadwriteBll=new V_Auth_Per_U00000B_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000B_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000B_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 272 业务接口
		IV_Auth_Per_U00000B_System_PersonClassBLL iV_Auth_Per_U00000B_System_PersonClassBll;
		public IV_Auth_Per_U00000B_System_PersonClassBLL V_Auth_Per_U00000B_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_PersonClassBll==null)
					iV_Auth_Per_U00000B_System_PersonClassBll=new V_Auth_Per_U00000B_System_PersonClassBLL();
				return iV_Auth_Per_U00000B_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000B_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 273 业务接口
		IV_Auth_Per_U00000C_System_BPM_StartBLL iV_Auth_Per_U00000C_System_BPM_StartBll;
		public IV_Auth_Per_U00000C_System_BPM_StartBLL V_Auth_Per_U00000C_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_BPM_StartBll==null)
					iV_Auth_Per_U00000C_System_BPM_StartBll=new V_Auth_Per_U00000C_System_BPM_StartBLL();
				return iV_Auth_Per_U00000C_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000C_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 274 业务接口
		IV_Auth_Per_U00000C_System_Operation_StartBLL iV_Auth_Per_U00000C_System_Operation_StartBll;
		public IV_Auth_Per_U00000C_System_Operation_StartBLL V_Auth_Per_U00000C_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_Operation_StartBll==null)
					iV_Auth_Per_U00000C_System_Operation_StartBll=new V_Auth_Per_U00000C_System_Operation_StartBLL();
				return iV_Auth_Per_U00000C_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000C_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 275 业务接口
		IV_Auth_Per_U00000C_System_Org_TreeBLL iV_Auth_Per_U00000C_System_Org_TreeBll;
		public IV_Auth_Per_U00000C_System_Org_TreeBLL V_Auth_Per_U00000C_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_Org_TreeBll==null)
					iV_Auth_Per_U00000C_System_Org_TreeBll=new V_Auth_Per_U00000C_System_Org_TreeBLL();
				return iV_Auth_Per_U00000C_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000C_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 276 业务接口
		IV_Auth_Per_U00000C_System_Person_ReadwriteBLL iV_Auth_Per_U00000C_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000C_System_Person_ReadwriteBLL V_Auth_Per_U00000C_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000C_System_Person_ReadwriteBll=new V_Auth_Per_U00000C_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000C_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000C_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 277 业务接口
		IV_Auth_Per_U00000C_System_PersonClassBLL iV_Auth_Per_U00000C_System_PersonClassBll;
		public IV_Auth_Per_U00000C_System_PersonClassBLL V_Auth_Per_U00000C_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_PersonClassBll==null)
					iV_Auth_Per_U00000C_System_PersonClassBll=new V_Auth_Per_U00000C_System_PersonClassBLL();
				return iV_Auth_Per_U00000C_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000C_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 278 业务接口
		IV_Auth_Per_U00000D_System_BPM_StartBLL iV_Auth_Per_U00000D_System_BPM_StartBll;
		public IV_Auth_Per_U00000D_System_BPM_StartBLL V_Auth_Per_U00000D_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_BPM_StartBll==null)
					iV_Auth_Per_U00000D_System_BPM_StartBll=new V_Auth_Per_U00000D_System_BPM_StartBLL();
				return iV_Auth_Per_U00000D_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000D_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 279 业务接口
		IV_Auth_Per_U00000D_System_Operation_StartBLL iV_Auth_Per_U00000D_System_Operation_StartBll;
		public IV_Auth_Per_U00000D_System_Operation_StartBLL V_Auth_Per_U00000D_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_Operation_StartBll==null)
					iV_Auth_Per_U00000D_System_Operation_StartBll=new V_Auth_Per_U00000D_System_Operation_StartBLL();
				return iV_Auth_Per_U00000D_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000D_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 280 业务接口
		IV_Auth_Per_U00000D_System_Org_TreeBLL iV_Auth_Per_U00000D_System_Org_TreeBll;
		public IV_Auth_Per_U00000D_System_Org_TreeBLL V_Auth_Per_U00000D_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_Org_TreeBll==null)
					iV_Auth_Per_U00000D_System_Org_TreeBll=new V_Auth_Per_U00000D_System_Org_TreeBLL();
				return iV_Auth_Per_U00000D_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000D_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 281 业务接口
		IV_Auth_Per_U00000D_System_Person_ReadwriteBLL iV_Auth_Per_U00000D_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000D_System_Person_ReadwriteBLL V_Auth_Per_U00000D_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000D_System_Person_ReadwriteBll=new V_Auth_Per_U00000D_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000D_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000D_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 282 业务接口
		IV_Auth_Per_U00000D_System_PersonClassBLL iV_Auth_Per_U00000D_System_PersonClassBll;
		public IV_Auth_Per_U00000D_System_PersonClassBLL V_Auth_Per_U00000D_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_PersonClassBll==null)
					iV_Auth_Per_U00000D_System_PersonClassBll=new V_Auth_Per_U00000D_System_PersonClassBLL();
				return iV_Auth_Per_U00000D_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000D_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 283 业务接口
		IV_Auth_Per_U00000E_System_BPM_StartBLL iV_Auth_Per_U00000E_System_BPM_StartBll;
		public IV_Auth_Per_U00000E_System_BPM_StartBLL V_Auth_Per_U00000E_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_BPM_StartBll==null)
					iV_Auth_Per_U00000E_System_BPM_StartBll=new V_Auth_Per_U00000E_System_BPM_StartBLL();
				return iV_Auth_Per_U00000E_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000E_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 284 业务接口
		IV_Auth_Per_U00000E_System_Operation_StartBLL iV_Auth_Per_U00000E_System_Operation_StartBll;
		public IV_Auth_Per_U00000E_System_Operation_StartBLL V_Auth_Per_U00000E_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_Operation_StartBll==null)
					iV_Auth_Per_U00000E_System_Operation_StartBll=new V_Auth_Per_U00000E_System_Operation_StartBLL();
				return iV_Auth_Per_U00000E_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000E_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 285 业务接口
		IV_Auth_Per_U00000E_System_Org_TreeBLL iV_Auth_Per_U00000E_System_Org_TreeBll;
		public IV_Auth_Per_U00000E_System_Org_TreeBLL V_Auth_Per_U00000E_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_Org_TreeBll==null)
					iV_Auth_Per_U00000E_System_Org_TreeBll=new V_Auth_Per_U00000E_System_Org_TreeBLL();
				return iV_Auth_Per_U00000E_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000E_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 286 业务接口
		IV_Auth_Per_U00000E_System_Person_ReadwriteBLL iV_Auth_Per_U00000E_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000E_System_Person_ReadwriteBLL V_Auth_Per_U00000E_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000E_System_Person_ReadwriteBll=new V_Auth_Per_U00000E_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000E_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000E_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 287 业务接口
		IV_Auth_Per_U00000E_System_PersonClassBLL iV_Auth_Per_U00000E_System_PersonClassBll;
		public IV_Auth_Per_U00000E_System_PersonClassBLL V_Auth_Per_U00000E_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_PersonClassBll==null)
					iV_Auth_Per_U00000E_System_PersonClassBll=new V_Auth_Per_U00000E_System_PersonClassBLL();
				return iV_Auth_Per_U00000E_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000E_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 288 业务接口
		IV_Auth_Per_U00000F_System_BPM_StartBLL iV_Auth_Per_U00000F_System_BPM_StartBll;
		public IV_Auth_Per_U00000F_System_BPM_StartBLL V_Auth_Per_U00000F_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_BPM_StartBll==null)
					iV_Auth_Per_U00000F_System_BPM_StartBll=new V_Auth_Per_U00000F_System_BPM_StartBLL();
				return iV_Auth_Per_U00000F_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000F_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 289 业务接口
		IV_Auth_Per_U00000F_System_Operation_StartBLL iV_Auth_Per_U00000F_System_Operation_StartBll;
		public IV_Auth_Per_U00000F_System_Operation_StartBLL V_Auth_Per_U00000F_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_Operation_StartBll==null)
					iV_Auth_Per_U00000F_System_Operation_StartBll=new V_Auth_Per_U00000F_System_Operation_StartBLL();
				return iV_Auth_Per_U00000F_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000F_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 290 业务接口
		IV_Auth_Per_U00000F_System_Org_TreeBLL iV_Auth_Per_U00000F_System_Org_TreeBll;
		public IV_Auth_Per_U00000F_System_Org_TreeBLL V_Auth_Per_U00000F_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_Org_TreeBll==null)
					iV_Auth_Per_U00000F_System_Org_TreeBll=new V_Auth_Per_U00000F_System_Org_TreeBLL();
				return iV_Auth_Per_U00000F_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000F_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 291 业务接口
		IV_Auth_Per_U00000F_System_Person_ReadwriteBLL iV_Auth_Per_U00000F_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000F_System_Person_ReadwriteBLL V_Auth_Per_U00000F_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000F_System_Person_ReadwriteBll=new V_Auth_Per_U00000F_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000F_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000F_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 292 业务接口
		IV_Auth_Per_U00000F_System_PersonClassBLL iV_Auth_Per_U00000F_System_PersonClassBll;
		public IV_Auth_Per_U00000F_System_PersonClassBLL V_Auth_Per_U00000F_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_PersonClassBll==null)
					iV_Auth_Per_U00000F_System_PersonClassBll=new V_Auth_Per_U00000F_System_PersonClassBLL();
				return iV_Auth_Per_U00000F_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000F_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 293 业务接口
		IV_Auth_Per_U00000G_System_BPM_StartBLL iV_Auth_Per_U00000G_System_BPM_StartBll;
		public IV_Auth_Per_U00000G_System_BPM_StartBLL V_Auth_Per_U00000G_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_BPM_StartBll==null)
					iV_Auth_Per_U00000G_System_BPM_StartBll=new V_Auth_Per_U00000G_System_BPM_StartBLL();
				return iV_Auth_Per_U00000G_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000G_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 294 业务接口
		IV_Auth_Per_U00000G_System_Operation_StartBLL iV_Auth_Per_U00000G_System_Operation_StartBll;
		public IV_Auth_Per_U00000G_System_Operation_StartBLL V_Auth_Per_U00000G_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_Operation_StartBll==null)
					iV_Auth_Per_U00000G_System_Operation_StartBll=new V_Auth_Per_U00000G_System_Operation_StartBLL();
				return iV_Auth_Per_U00000G_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000G_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 295 业务接口
		IV_Auth_Per_U00000G_System_Org_TreeBLL iV_Auth_Per_U00000G_System_Org_TreeBll;
		public IV_Auth_Per_U00000G_System_Org_TreeBLL V_Auth_Per_U00000G_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_Org_TreeBll==null)
					iV_Auth_Per_U00000G_System_Org_TreeBll=new V_Auth_Per_U00000G_System_Org_TreeBLL();
				return iV_Auth_Per_U00000G_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000G_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 296 业务接口
		IV_Auth_Per_U00000G_System_Person_ReadwriteBLL iV_Auth_Per_U00000G_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000G_System_Person_ReadwriteBLL V_Auth_Per_U00000G_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000G_System_Person_ReadwriteBll=new V_Auth_Per_U00000G_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000G_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000G_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 297 业务接口
		IV_Auth_Per_U00000G_System_PersonClassBLL iV_Auth_Per_U00000G_System_PersonClassBll;
		public IV_Auth_Per_U00000G_System_PersonClassBLL V_Auth_Per_U00000G_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_PersonClassBll==null)
					iV_Auth_Per_U00000G_System_PersonClassBll=new V_Auth_Per_U00000G_System_PersonClassBLL();
				return iV_Auth_Per_U00000G_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000G_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 298 业务接口
		IV_Auth_Per_U00000I_System_BPM_StartBLL iV_Auth_Per_U00000I_System_BPM_StartBll;
		public IV_Auth_Per_U00000I_System_BPM_StartBLL V_Auth_Per_U00000I_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_BPM_StartBll==null)
					iV_Auth_Per_U00000I_System_BPM_StartBll=new V_Auth_Per_U00000I_System_BPM_StartBLL();
				return iV_Auth_Per_U00000I_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000I_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 299 业务接口
		IV_Auth_Per_U00000I_System_Operation_StartBLL iV_Auth_Per_U00000I_System_Operation_StartBll;
		public IV_Auth_Per_U00000I_System_Operation_StartBLL V_Auth_Per_U00000I_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_Operation_StartBll==null)
					iV_Auth_Per_U00000I_System_Operation_StartBll=new V_Auth_Per_U00000I_System_Operation_StartBLL();
				return iV_Auth_Per_U00000I_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000I_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 300 业务接口
		IV_Auth_Per_U00000I_System_Org_TreeBLL iV_Auth_Per_U00000I_System_Org_TreeBll;
		public IV_Auth_Per_U00000I_System_Org_TreeBLL V_Auth_Per_U00000I_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_Org_TreeBll==null)
					iV_Auth_Per_U00000I_System_Org_TreeBll=new V_Auth_Per_U00000I_System_Org_TreeBLL();
				return iV_Auth_Per_U00000I_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000I_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 301 业务接口
		IV_Auth_Per_U00000I_System_Person_ReadwriteBLL iV_Auth_Per_U00000I_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000I_System_Person_ReadwriteBLL V_Auth_Per_U00000I_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000I_System_Person_ReadwriteBll=new V_Auth_Per_U00000I_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000I_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000I_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 302 业务接口
		IV_Auth_Per_U00000I_System_PersonClassBLL iV_Auth_Per_U00000I_System_PersonClassBll;
		public IV_Auth_Per_U00000I_System_PersonClassBLL V_Auth_Per_U00000I_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_PersonClassBll==null)
					iV_Auth_Per_U00000I_System_PersonClassBll=new V_Auth_Per_U00000I_System_PersonClassBLL();
				return iV_Auth_Per_U00000I_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000I_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 303 业务接口
		IV_Auth_Per_U00000J_System_BPM_StartBLL iV_Auth_Per_U00000J_System_BPM_StartBll;
		public IV_Auth_Per_U00000J_System_BPM_StartBLL V_Auth_Per_U00000J_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_BPM_StartBll==null)
					iV_Auth_Per_U00000J_System_BPM_StartBll=new V_Auth_Per_U00000J_System_BPM_StartBLL();
				return iV_Auth_Per_U00000J_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000J_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 304 业务接口
		IV_Auth_Per_U00000J_System_Operation_StartBLL iV_Auth_Per_U00000J_System_Operation_StartBll;
		public IV_Auth_Per_U00000J_System_Operation_StartBLL V_Auth_Per_U00000J_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_Operation_StartBll==null)
					iV_Auth_Per_U00000J_System_Operation_StartBll=new V_Auth_Per_U00000J_System_Operation_StartBLL();
				return iV_Auth_Per_U00000J_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000J_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 305 业务接口
		IV_Auth_Per_U00000J_System_Org_TreeBLL iV_Auth_Per_U00000J_System_Org_TreeBll;
		public IV_Auth_Per_U00000J_System_Org_TreeBLL V_Auth_Per_U00000J_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_Org_TreeBll==null)
					iV_Auth_Per_U00000J_System_Org_TreeBll=new V_Auth_Per_U00000J_System_Org_TreeBLL();
				return iV_Auth_Per_U00000J_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000J_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 306 业务接口
		IV_Auth_Per_U00000J_System_Person_ReadwriteBLL iV_Auth_Per_U00000J_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000J_System_Person_ReadwriteBLL V_Auth_Per_U00000J_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000J_System_Person_ReadwriteBll=new V_Auth_Per_U00000J_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000J_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000J_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 307 业务接口
		IV_Auth_Per_U00000J_System_PersonClassBLL iV_Auth_Per_U00000J_System_PersonClassBll;
		public IV_Auth_Per_U00000J_System_PersonClassBLL V_Auth_Per_U00000J_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_PersonClassBll==null)
					iV_Auth_Per_U00000J_System_PersonClassBll=new V_Auth_Per_U00000J_System_PersonClassBLL();
				return iV_Auth_Per_U00000J_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000J_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 308 业务接口
		IV_Auth_Per_U00000K_System_BPM_StartBLL iV_Auth_Per_U00000K_System_BPM_StartBll;
		public IV_Auth_Per_U00000K_System_BPM_StartBLL V_Auth_Per_U00000K_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_BPM_StartBll==null)
					iV_Auth_Per_U00000K_System_BPM_StartBll=new V_Auth_Per_U00000K_System_BPM_StartBLL();
				return iV_Auth_Per_U00000K_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000K_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 309 业务接口
		IV_Auth_Per_U00000K_System_Operation_StartBLL iV_Auth_Per_U00000K_System_Operation_StartBll;
		public IV_Auth_Per_U00000K_System_Operation_StartBLL V_Auth_Per_U00000K_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_Operation_StartBll==null)
					iV_Auth_Per_U00000K_System_Operation_StartBll=new V_Auth_Per_U00000K_System_Operation_StartBLL();
				return iV_Auth_Per_U00000K_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000K_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 310 业务接口
		IV_Auth_Per_U00000K_System_Org_TreeBLL iV_Auth_Per_U00000K_System_Org_TreeBll;
		public IV_Auth_Per_U00000K_System_Org_TreeBLL V_Auth_Per_U00000K_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_Org_TreeBll==null)
					iV_Auth_Per_U00000K_System_Org_TreeBll=new V_Auth_Per_U00000K_System_Org_TreeBLL();
				return iV_Auth_Per_U00000K_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000K_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 311 业务接口
		IV_Auth_Per_U00000K_System_Person_ReadwriteBLL iV_Auth_Per_U00000K_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000K_System_Person_ReadwriteBLL V_Auth_Per_U00000K_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000K_System_Person_ReadwriteBll=new V_Auth_Per_U00000K_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000K_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000K_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 312 业务接口
		IV_Auth_Per_U00000K_System_PersonClassBLL iV_Auth_Per_U00000K_System_PersonClassBll;
		public IV_Auth_Per_U00000K_System_PersonClassBLL V_Auth_Per_U00000K_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_PersonClassBll==null)
					iV_Auth_Per_U00000K_System_PersonClassBll=new V_Auth_Per_U00000K_System_PersonClassBLL();
				return iV_Auth_Per_U00000K_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000K_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 313 业务接口
		IV_Auth_Per_U00000L_System_BPM_StartBLL iV_Auth_Per_U00000L_System_BPM_StartBll;
		public IV_Auth_Per_U00000L_System_BPM_StartBLL V_Auth_Per_U00000L_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_BPM_StartBll==null)
					iV_Auth_Per_U00000L_System_BPM_StartBll=new V_Auth_Per_U00000L_System_BPM_StartBLL();
				return iV_Auth_Per_U00000L_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000L_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 314 业务接口
		IV_Auth_Per_U00000L_System_Operation_StartBLL iV_Auth_Per_U00000L_System_Operation_StartBll;
		public IV_Auth_Per_U00000L_System_Operation_StartBLL V_Auth_Per_U00000L_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_Operation_StartBll==null)
					iV_Auth_Per_U00000L_System_Operation_StartBll=new V_Auth_Per_U00000L_System_Operation_StartBLL();
				return iV_Auth_Per_U00000L_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000L_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 315 业务接口
		IV_Auth_Per_U00000L_System_Org_TreeBLL iV_Auth_Per_U00000L_System_Org_TreeBll;
		public IV_Auth_Per_U00000L_System_Org_TreeBLL V_Auth_Per_U00000L_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_Org_TreeBll==null)
					iV_Auth_Per_U00000L_System_Org_TreeBll=new V_Auth_Per_U00000L_System_Org_TreeBLL();
				return iV_Auth_Per_U00000L_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000L_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 316 业务接口
		IV_Auth_Per_U00000L_System_Person_ReadwriteBLL iV_Auth_Per_U00000L_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000L_System_Person_ReadwriteBLL V_Auth_Per_U00000L_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000L_System_Person_ReadwriteBll=new V_Auth_Per_U00000L_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000L_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000L_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 317 业务接口
		IV_Auth_Per_U00000L_System_PersonClassBLL iV_Auth_Per_U00000L_System_PersonClassBll;
		public IV_Auth_Per_U00000L_System_PersonClassBLL V_Auth_Per_U00000L_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_PersonClassBll==null)
					iV_Auth_Per_U00000L_System_PersonClassBll=new V_Auth_Per_U00000L_System_PersonClassBLL();
				return iV_Auth_Per_U00000L_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000L_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 318 业务接口
		IV_Auth_Per_U00000M_System_BPM_StartBLL iV_Auth_Per_U00000M_System_BPM_StartBll;
		public IV_Auth_Per_U00000M_System_BPM_StartBLL V_Auth_Per_U00000M_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_BPM_StartBll==null)
					iV_Auth_Per_U00000M_System_BPM_StartBll=new V_Auth_Per_U00000M_System_BPM_StartBLL();
				return iV_Auth_Per_U00000M_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000M_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 319 业务接口
		IV_Auth_Per_U00000M_System_Operation_StartBLL iV_Auth_Per_U00000M_System_Operation_StartBll;
		public IV_Auth_Per_U00000M_System_Operation_StartBLL V_Auth_Per_U00000M_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_Operation_StartBll==null)
					iV_Auth_Per_U00000M_System_Operation_StartBll=new V_Auth_Per_U00000M_System_Operation_StartBLL();
				return iV_Auth_Per_U00000M_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000M_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 320 业务接口
		IV_Auth_Per_U00000M_System_Org_TreeBLL iV_Auth_Per_U00000M_System_Org_TreeBll;
		public IV_Auth_Per_U00000M_System_Org_TreeBLL V_Auth_Per_U00000M_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_Org_TreeBll==null)
					iV_Auth_Per_U00000M_System_Org_TreeBll=new V_Auth_Per_U00000M_System_Org_TreeBLL();
				return iV_Auth_Per_U00000M_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000M_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 321 业务接口
		IV_Auth_Per_U00000M_System_Person_ReadwriteBLL iV_Auth_Per_U00000M_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000M_System_Person_ReadwriteBLL V_Auth_Per_U00000M_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000M_System_Person_ReadwriteBll=new V_Auth_Per_U00000M_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000M_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000M_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 322 业务接口
		IV_Auth_Per_U00000M_System_PersonClassBLL iV_Auth_Per_U00000M_System_PersonClassBll;
		public IV_Auth_Per_U00000M_System_PersonClassBLL V_Auth_Per_U00000M_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_PersonClassBll==null)
					iV_Auth_Per_U00000M_System_PersonClassBll=new V_Auth_Per_U00000M_System_PersonClassBLL();
				return iV_Auth_Per_U00000M_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000M_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 323 业务接口
		IV_Auth_Per_U00000O_System_BPM_StartBLL iV_Auth_Per_U00000O_System_BPM_StartBll;
		public IV_Auth_Per_U00000O_System_BPM_StartBLL V_Auth_Per_U00000O_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_BPM_StartBll==null)
					iV_Auth_Per_U00000O_System_BPM_StartBll=new V_Auth_Per_U00000O_System_BPM_StartBLL();
				return iV_Auth_Per_U00000O_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000O_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 324 业务接口
		IV_Auth_Per_U00000O_System_Operation_StartBLL iV_Auth_Per_U00000O_System_Operation_StartBll;
		public IV_Auth_Per_U00000O_System_Operation_StartBLL V_Auth_Per_U00000O_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_Operation_StartBll==null)
					iV_Auth_Per_U00000O_System_Operation_StartBll=new V_Auth_Per_U00000O_System_Operation_StartBLL();
				return iV_Auth_Per_U00000O_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000O_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 325 业务接口
		IV_Auth_Per_U00000O_System_Org_TreeBLL iV_Auth_Per_U00000O_System_Org_TreeBll;
		public IV_Auth_Per_U00000O_System_Org_TreeBLL V_Auth_Per_U00000O_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_Org_TreeBll==null)
					iV_Auth_Per_U00000O_System_Org_TreeBll=new V_Auth_Per_U00000O_System_Org_TreeBLL();
				return iV_Auth_Per_U00000O_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000O_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 326 业务接口
		IV_Auth_Per_U00000O_System_Person_ReadwriteBLL iV_Auth_Per_U00000O_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000O_System_Person_ReadwriteBLL V_Auth_Per_U00000O_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000O_System_Person_ReadwriteBll=new V_Auth_Per_U00000O_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000O_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000O_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 327 业务接口
		IV_Auth_Per_U00000O_System_PersonClassBLL iV_Auth_Per_U00000O_System_PersonClassBll;
		public IV_Auth_Per_U00000O_System_PersonClassBLL V_Auth_Per_U00000O_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_PersonClassBll==null)
					iV_Auth_Per_U00000O_System_PersonClassBll=new V_Auth_Per_U00000O_System_PersonClassBLL();
				return iV_Auth_Per_U00000O_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000O_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 328 业务接口
		IV_Auth_Per_U00000P_System_BPM_StartBLL iV_Auth_Per_U00000P_System_BPM_StartBll;
		public IV_Auth_Per_U00000P_System_BPM_StartBLL V_Auth_Per_U00000P_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_BPM_StartBll==null)
					iV_Auth_Per_U00000P_System_BPM_StartBll=new V_Auth_Per_U00000P_System_BPM_StartBLL();
				return iV_Auth_Per_U00000P_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000P_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 329 业务接口
		IV_Auth_Per_U00000P_System_Operation_StartBLL iV_Auth_Per_U00000P_System_Operation_StartBll;
		public IV_Auth_Per_U00000P_System_Operation_StartBLL V_Auth_Per_U00000P_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_Operation_StartBll==null)
					iV_Auth_Per_U00000P_System_Operation_StartBll=new V_Auth_Per_U00000P_System_Operation_StartBLL();
				return iV_Auth_Per_U00000P_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000P_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 330 业务接口
		IV_Auth_Per_U00000P_System_Org_TreeBLL iV_Auth_Per_U00000P_System_Org_TreeBll;
		public IV_Auth_Per_U00000P_System_Org_TreeBLL V_Auth_Per_U00000P_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_Org_TreeBll==null)
					iV_Auth_Per_U00000P_System_Org_TreeBll=new V_Auth_Per_U00000P_System_Org_TreeBLL();
				return iV_Auth_Per_U00000P_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000P_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 331 业务接口
		IV_Auth_Per_U00000P_System_Person_ReadwriteBLL iV_Auth_Per_U00000P_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000P_System_Person_ReadwriteBLL V_Auth_Per_U00000P_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000P_System_Person_ReadwriteBll=new V_Auth_Per_U00000P_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000P_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000P_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 332 业务接口
		IV_Auth_Per_U00000P_System_PersonClassBLL iV_Auth_Per_U00000P_System_PersonClassBll;
		public IV_Auth_Per_U00000P_System_PersonClassBLL V_Auth_Per_U00000P_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_PersonClassBll==null)
					iV_Auth_Per_U00000P_System_PersonClassBll=new V_Auth_Per_U00000P_System_PersonClassBLL();
				return iV_Auth_Per_U00000P_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000P_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 333 业务接口
		IV_Auth_Per_U00000R_System_BPM_StartBLL iV_Auth_Per_U00000R_System_BPM_StartBll;
		public IV_Auth_Per_U00000R_System_BPM_StartBLL V_Auth_Per_U00000R_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_BPM_StartBll==null)
					iV_Auth_Per_U00000R_System_BPM_StartBll=new V_Auth_Per_U00000R_System_BPM_StartBLL();
				return iV_Auth_Per_U00000R_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000R_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 334 业务接口
		IV_Auth_Per_U00000R_System_Operation_StartBLL iV_Auth_Per_U00000R_System_Operation_StartBll;
		public IV_Auth_Per_U00000R_System_Operation_StartBLL V_Auth_Per_U00000R_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_Operation_StartBll==null)
					iV_Auth_Per_U00000R_System_Operation_StartBll=new V_Auth_Per_U00000R_System_Operation_StartBLL();
				return iV_Auth_Per_U00000R_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000R_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 335 业务接口
		IV_Auth_Per_U00000R_System_Org_TreeBLL iV_Auth_Per_U00000R_System_Org_TreeBll;
		public IV_Auth_Per_U00000R_System_Org_TreeBLL V_Auth_Per_U00000R_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_Org_TreeBll==null)
					iV_Auth_Per_U00000R_System_Org_TreeBll=new V_Auth_Per_U00000R_System_Org_TreeBLL();
				return iV_Auth_Per_U00000R_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000R_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 336 业务接口
		IV_Auth_Per_U00000R_System_Person_ReadwriteBLL iV_Auth_Per_U00000R_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000R_System_Person_ReadwriteBLL V_Auth_Per_U00000R_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000R_System_Person_ReadwriteBll=new V_Auth_Per_U00000R_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000R_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000R_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 337 业务接口
		IV_Auth_Per_U00000R_System_PersonClassBLL iV_Auth_Per_U00000R_System_PersonClassBll;
		public IV_Auth_Per_U00000R_System_PersonClassBLL V_Auth_Per_U00000R_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_PersonClassBll==null)
					iV_Auth_Per_U00000R_System_PersonClassBll=new V_Auth_Per_U00000R_System_PersonClassBLL();
				return iV_Auth_Per_U00000R_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000R_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 338 业务接口
		IV_Auth_Per_U00000S_System_BPM_StartBLL iV_Auth_Per_U00000S_System_BPM_StartBll;
		public IV_Auth_Per_U00000S_System_BPM_StartBLL V_Auth_Per_U00000S_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_BPM_StartBll==null)
					iV_Auth_Per_U00000S_System_BPM_StartBll=new V_Auth_Per_U00000S_System_BPM_StartBLL();
				return iV_Auth_Per_U00000S_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000S_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 339 业务接口
		IV_Auth_Per_U00000S_System_Operation_StartBLL iV_Auth_Per_U00000S_System_Operation_StartBll;
		public IV_Auth_Per_U00000S_System_Operation_StartBLL V_Auth_Per_U00000S_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_Operation_StartBll==null)
					iV_Auth_Per_U00000S_System_Operation_StartBll=new V_Auth_Per_U00000S_System_Operation_StartBLL();
				return iV_Auth_Per_U00000S_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000S_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 340 业务接口
		IV_Auth_Per_U00000S_System_Org_TreeBLL iV_Auth_Per_U00000S_System_Org_TreeBll;
		public IV_Auth_Per_U00000S_System_Org_TreeBLL V_Auth_Per_U00000S_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_Org_TreeBll==null)
					iV_Auth_Per_U00000S_System_Org_TreeBll=new V_Auth_Per_U00000S_System_Org_TreeBLL();
				return iV_Auth_Per_U00000S_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000S_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 341 业务接口
		IV_Auth_Per_U00000S_System_Person_ReadwriteBLL iV_Auth_Per_U00000S_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000S_System_Person_ReadwriteBLL V_Auth_Per_U00000S_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000S_System_Person_ReadwriteBll=new V_Auth_Per_U00000S_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000S_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000S_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 342 业务接口
		IV_Auth_Per_U00000S_System_PersonClassBLL iV_Auth_Per_U00000S_System_PersonClassBll;
		public IV_Auth_Per_U00000S_System_PersonClassBLL V_Auth_Per_U00000S_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_PersonClassBll==null)
					iV_Auth_Per_U00000S_System_PersonClassBll=new V_Auth_Per_U00000S_System_PersonClassBLL();
				return iV_Auth_Per_U00000S_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000S_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 343 业务接口
		IV_Auth_Per_U00000T_System_BPM_StartBLL iV_Auth_Per_U00000T_System_BPM_StartBll;
		public IV_Auth_Per_U00000T_System_BPM_StartBLL V_Auth_Per_U00000T_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_BPM_StartBll==null)
					iV_Auth_Per_U00000T_System_BPM_StartBll=new V_Auth_Per_U00000T_System_BPM_StartBLL();
				return iV_Auth_Per_U00000T_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000T_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 344 业务接口
		IV_Auth_Per_U00000T_System_Operation_StartBLL iV_Auth_Per_U00000T_System_Operation_StartBll;
		public IV_Auth_Per_U00000T_System_Operation_StartBLL V_Auth_Per_U00000T_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_Operation_StartBll==null)
					iV_Auth_Per_U00000T_System_Operation_StartBll=new V_Auth_Per_U00000T_System_Operation_StartBLL();
				return iV_Auth_Per_U00000T_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000T_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 345 业务接口
		IV_Auth_Per_U00000T_System_Org_TreeBLL iV_Auth_Per_U00000T_System_Org_TreeBll;
		public IV_Auth_Per_U00000T_System_Org_TreeBLL V_Auth_Per_U00000T_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_Org_TreeBll==null)
					iV_Auth_Per_U00000T_System_Org_TreeBll=new V_Auth_Per_U00000T_System_Org_TreeBLL();
				return iV_Auth_Per_U00000T_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000T_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 346 业务接口
		IV_Auth_Per_U00000T_System_Person_ReadwriteBLL iV_Auth_Per_U00000T_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000T_System_Person_ReadwriteBLL V_Auth_Per_U00000T_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000T_System_Person_ReadwriteBll=new V_Auth_Per_U00000T_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000T_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000T_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 347 业务接口
		IV_Auth_Per_U00000T_System_PersonClassBLL iV_Auth_Per_U00000T_System_PersonClassBll;
		public IV_Auth_Per_U00000T_System_PersonClassBLL V_Auth_Per_U00000T_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_PersonClassBll==null)
					iV_Auth_Per_U00000T_System_PersonClassBll=new V_Auth_Per_U00000T_System_PersonClassBLL();
				return iV_Auth_Per_U00000T_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000T_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 348 业务接口
		IV_Auth_Per_U00000U_System_BPM_StartBLL iV_Auth_Per_U00000U_System_BPM_StartBll;
		public IV_Auth_Per_U00000U_System_BPM_StartBLL V_Auth_Per_U00000U_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_BPM_StartBll==null)
					iV_Auth_Per_U00000U_System_BPM_StartBll=new V_Auth_Per_U00000U_System_BPM_StartBLL();
				return iV_Auth_Per_U00000U_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000U_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 349 业务接口
		IV_Auth_Per_U00000U_System_Operation_StartBLL iV_Auth_Per_U00000U_System_Operation_StartBll;
		public IV_Auth_Per_U00000U_System_Operation_StartBLL V_Auth_Per_U00000U_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_Operation_StartBll==null)
					iV_Auth_Per_U00000U_System_Operation_StartBll=new V_Auth_Per_U00000U_System_Operation_StartBLL();
				return iV_Auth_Per_U00000U_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000U_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 350 业务接口
		IV_Auth_Per_U00000U_System_Org_TreeBLL iV_Auth_Per_U00000U_System_Org_TreeBll;
		public IV_Auth_Per_U00000U_System_Org_TreeBLL V_Auth_Per_U00000U_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_Org_TreeBll==null)
					iV_Auth_Per_U00000U_System_Org_TreeBll=new V_Auth_Per_U00000U_System_Org_TreeBLL();
				return iV_Auth_Per_U00000U_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000U_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 351 业务接口
		IV_Auth_Per_U00000U_System_Person_ReadwriteBLL iV_Auth_Per_U00000U_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000U_System_Person_ReadwriteBLL V_Auth_Per_U00000U_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000U_System_Person_ReadwriteBll=new V_Auth_Per_U00000U_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000U_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000U_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 352 业务接口
		IV_Auth_Per_U00000U_System_PersonClassBLL iV_Auth_Per_U00000U_System_PersonClassBll;
		public IV_Auth_Per_U00000U_System_PersonClassBLL V_Auth_Per_U00000U_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_PersonClassBll==null)
					iV_Auth_Per_U00000U_System_PersonClassBll=new V_Auth_Per_U00000U_System_PersonClassBLL();
				return iV_Auth_Per_U00000U_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000U_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 353 业务接口
		IV_Auth_Per_U00000V_System_BPM_StartBLL iV_Auth_Per_U00000V_System_BPM_StartBll;
		public IV_Auth_Per_U00000V_System_BPM_StartBLL V_Auth_Per_U00000V_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_BPM_StartBll==null)
					iV_Auth_Per_U00000V_System_BPM_StartBll=new V_Auth_Per_U00000V_System_BPM_StartBLL();
				return iV_Auth_Per_U00000V_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000V_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 354 业务接口
		IV_Auth_Per_U00000V_System_Operation_StartBLL iV_Auth_Per_U00000V_System_Operation_StartBll;
		public IV_Auth_Per_U00000V_System_Operation_StartBLL V_Auth_Per_U00000V_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_Operation_StartBll==null)
					iV_Auth_Per_U00000V_System_Operation_StartBll=new V_Auth_Per_U00000V_System_Operation_StartBLL();
				return iV_Auth_Per_U00000V_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000V_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 355 业务接口
		IV_Auth_Per_U00000V_System_Org_TreeBLL iV_Auth_Per_U00000V_System_Org_TreeBll;
		public IV_Auth_Per_U00000V_System_Org_TreeBLL V_Auth_Per_U00000V_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_Org_TreeBll==null)
					iV_Auth_Per_U00000V_System_Org_TreeBll=new V_Auth_Per_U00000V_System_Org_TreeBLL();
				return iV_Auth_Per_U00000V_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000V_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 356 业务接口
		IV_Auth_Per_U00000V_System_Person_ReadwriteBLL iV_Auth_Per_U00000V_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000V_System_Person_ReadwriteBLL V_Auth_Per_U00000V_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000V_System_Person_ReadwriteBll=new V_Auth_Per_U00000V_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000V_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000V_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 357 业务接口
		IV_Auth_Per_U00000V_System_PersonClassBLL iV_Auth_Per_U00000V_System_PersonClassBll;
		public IV_Auth_Per_U00000V_System_PersonClassBLL V_Auth_Per_U00000V_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_PersonClassBll==null)
					iV_Auth_Per_U00000V_System_PersonClassBll=new V_Auth_Per_U00000V_System_PersonClassBLL();
				return iV_Auth_Per_U00000V_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000V_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 358 业务接口
		IV_Auth_Per_U00000X_System_BPM_StartBLL iV_Auth_Per_U00000X_System_BPM_StartBll;
		public IV_Auth_Per_U00000X_System_BPM_StartBLL V_Auth_Per_U00000X_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_BPM_StartBll==null)
					iV_Auth_Per_U00000X_System_BPM_StartBll=new V_Auth_Per_U00000X_System_BPM_StartBLL();
				return iV_Auth_Per_U00000X_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000X_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 359 业务接口
		IV_Auth_Per_U00000X_System_Operation_StartBLL iV_Auth_Per_U00000X_System_Operation_StartBll;
		public IV_Auth_Per_U00000X_System_Operation_StartBLL V_Auth_Per_U00000X_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_Operation_StartBll==null)
					iV_Auth_Per_U00000X_System_Operation_StartBll=new V_Auth_Per_U00000X_System_Operation_StartBLL();
				return iV_Auth_Per_U00000X_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000X_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 360 业务接口
		IV_Auth_Per_U00000X_System_Org_TreeBLL iV_Auth_Per_U00000X_System_Org_TreeBll;
		public IV_Auth_Per_U00000X_System_Org_TreeBLL V_Auth_Per_U00000X_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_Org_TreeBll==null)
					iV_Auth_Per_U00000X_System_Org_TreeBll=new V_Auth_Per_U00000X_System_Org_TreeBLL();
				return iV_Auth_Per_U00000X_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000X_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 361 业务接口
		IV_Auth_Per_U00000X_System_Person_ReadwriteBLL iV_Auth_Per_U00000X_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000X_System_Person_ReadwriteBLL V_Auth_Per_U00000X_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000X_System_Person_ReadwriteBll=new V_Auth_Per_U00000X_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000X_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000X_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 362 业务接口
		IV_Auth_Per_U00000X_System_PersonClassBLL iV_Auth_Per_U00000X_System_PersonClassBll;
		public IV_Auth_Per_U00000X_System_PersonClassBLL V_Auth_Per_U00000X_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_PersonClassBll==null)
					iV_Auth_Per_U00000X_System_PersonClassBll=new V_Auth_Per_U00000X_System_PersonClassBLL();
				return iV_Auth_Per_U00000X_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000X_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 363 业务接口
		IV_Auth_Per_U00000Y_System_BPM_StartBLL iV_Auth_Per_U00000Y_System_BPM_StartBll;
		public IV_Auth_Per_U00000Y_System_BPM_StartBLL V_Auth_Per_U00000Y_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_BPM_StartBll==null)
					iV_Auth_Per_U00000Y_System_BPM_StartBll=new V_Auth_Per_U00000Y_System_BPM_StartBLL();
				return iV_Auth_Per_U00000Y_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 364 业务接口
		IV_Auth_Per_U00000Y_System_Operation_StartBLL iV_Auth_Per_U00000Y_System_Operation_StartBll;
		public IV_Auth_Per_U00000Y_System_Operation_StartBLL V_Auth_Per_U00000Y_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_Operation_StartBll==null)
					iV_Auth_Per_U00000Y_System_Operation_StartBll=new V_Auth_Per_U00000Y_System_Operation_StartBLL();
				return iV_Auth_Per_U00000Y_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 365 业务接口
		IV_Auth_Per_U00000Y_System_Org_TreeBLL iV_Auth_Per_U00000Y_System_Org_TreeBll;
		public IV_Auth_Per_U00000Y_System_Org_TreeBLL V_Auth_Per_U00000Y_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_Org_TreeBll==null)
					iV_Auth_Per_U00000Y_System_Org_TreeBll=new V_Auth_Per_U00000Y_System_Org_TreeBLL();
				return iV_Auth_Per_U00000Y_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 366 业务接口
		IV_Auth_Per_U00000Y_System_Person_ReadwriteBLL iV_Auth_Per_U00000Y_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000Y_System_Person_ReadwriteBLL V_Auth_Per_U00000Y_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000Y_System_Person_ReadwriteBll=new V_Auth_Per_U00000Y_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000Y_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 367 业务接口
		IV_Auth_Per_U00000Y_System_PersonClassBLL iV_Auth_Per_U00000Y_System_PersonClassBll;
		public IV_Auth_Per_U00000Y_System_PersonClassBLL V_Auth_Per_U00000Y_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_PersonClassBll==null)
					iV_Auth_Per_U00000Y_System_PersonClassBll=new V_Auth_Per_U00000Y_System_PersonClassBLL();
				return iV_Auth_Per_U00000Y_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 368 业务接口
		IV_Auth_Per_U00000Z_System_BPM_StartBLL iV_Auth_Per_U00000Z_System_BPM_StartBll;
		public IV_Auth_Per_U00000Z_System_BPM_StartBLL V_Auth_Per_U00000Z_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_BPM_StartBll==null)
					iV_Auth_Per_U00000Z_System_BPM_StartBll=new V_Auth_Per_U00000Z_System_BPM_StartBLL();
				return iV_Auth_Per_U00000Z_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 369 业务接口
		IV_Auth_Per_U00000Z_System_Operation_StartBLL iV_Auth_Per_U00000Z_System_Operation_StartBll;
		public IV_Auth_Per_U00000Z_System_Operation_StartBLL V_Auth_Per_U00000Z_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_Operation_StartBll==null)
					iV_Auth_Per_U00000Z_System_Operation_StartBll=new V_Auth_Per_U00000Z_System_Operation_StartBLL();
				return iV_Auth_Per_U00000Z_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 370 业务接口
		IV_Auth_Per_U00000Z_System_Org_TreeBLL iV_Auth_Per_U00000Z_System_Org_TreeBll;
		public IV_Auth_Per_U00000Z_System_Org_TreeBLL V_Auth_Per_U00000Z_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_Org_TreeBll==null)
					iV_Auth_Per_U00000Z_System_Org_TreeBll=new V_Auth_Per_U00000Z_System_Org_TreeBLL();
				return iV_Auth_Per_U00000Z_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 371 业务接口
		IV_Auth_Per_U00000Z_System_Person_ReadwriteBLL iV_Auth_Per_U00000Z_System_Person_ReadwriteBll;
		public IV_Auth_Per_U00000Z_System_Person_ReadwriteBLL V_Auth_Per_U00000Z_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U00000Z_System_Person_ReadwriteBll=new V_Auth_Per_U00000Z_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U00000Z_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 372 业务接口
		IV_Auth_Per_U00000Z_System_PersonClassBLL iV_Auth_Per_U00000Z_System_PersonClassBll;
		public IV_Auth_Per_U00000Z_System_PersonClassBLL V_Auth_Per_U00000Z_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_PersonClassBll==null)
					iV_Auth_Per_U00000Z_System_PersonClassBll=new V_Auth_Per_U00000Z_System_PersonClassBLL();
				return iV_Auth_Per_U00000Z_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 373 业务接口
		IV_Auth_Per_U000010_System_BPM_StartBLL iV_Auth_Per_U000010_System_BPM_StartBll;
		public IV_Auth_Per_U000010_System_BPM_StartBLL V_Auth_Per_U000010_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U000010_System_BPM_StartBll==null)
					iV_Auth_Per_U000010_System_BPM_StartBll=new V_Auth_Per_U000010_System_BPM_StartBLL();
				return iV_Auth_Per_U000010_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U000010_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 374 业务接口
		IV_Auth_Per_U000010_System_Operation_StartBLL iV_Auth_Per_U000010_System_Operation_StartBll;
		public IV_Auth_Per_U000010_System_Operation_StartBLL V_Auth_Per_U000010_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U000010_System_Operation_StartBll==null)
					iV_Auth_Per_U000010_System_Operation_StartBll=new V_Auth_Per_U000010_System_Operation_StartBLL();
				return iV_Auth_Per_U000010_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U000010_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 375 业务接口
		IV_Auth_Per_U000010_System_Org_TreeBLL iV_Auth_Per_U000010_System_Org_TreeBll;
		public IV_Auth_Per_U000010_System_Org_TreeBLL V_Auth_Per_U000010_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U000010_System_Org_TreeBll==null)
					iV_Auth_Per_U000010_System_Org_TreeBll=new V_Auth_Per_U000010_System_Org_TreeBLL();
				return iV_Auth_Per_U000010_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U000010_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 376 业务接口
		IV_Auth_Per_U000010_System_Person_ReadwriteBLL iV_Auth_Per_U000010_System_Person_ReadwriteBll;
		public IV_Auth_Per_U000010_System_Person_ReadwriteBLL V_Auth_Per_U000010_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U000010_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U000010_System_Person_ReadwriteBll=new V_Auth_Per_U000010_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U000010_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U000010_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 377 业务接口
		IV_Auth_Per_U000010_System_PersonClassBLL iV_Auth_Per_U000010_System_PersonClassBll;
		public IV_Auth_Per_U000010_System_PersonClassBLL V_Auth_Per_U000010_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U000010_System_PersonClassBll==null)
					iV_Auth_Per_U000010_System_PersonClassBll=new V_Auth_Per_U000010_System_PersonClassBLL();
				return iV_Auth_Per_U000010_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U000010_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 378 业务接口
		IV_Auth_Per_U000011_System_BPM_StartBLL iV_Auth_Per_U000011_System_BPM_StartBll;
		public IV_Auth_Per_U000011_System_BPM_StartBLL V_Auth_Per_U000011_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U000011_System_BPM_StartBll==null)
					iV_Auth_Per_U000011_System_BPM_StartBll=new V_Auth_Per_U000011_System_BPM_StartBLL();
				return iV_Auth_Per_U000011_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U000011_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 379 业务接口
		IV_Auth_Per_U000011_System_Operation_StartBLL iV_Auth_Per_U000011_System_Operation_StartBll;
		public IV_Auth_Per_U000011_System_Operation_StartBLL V_Auth_Per_U000011_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U000011_System_Operation_StartBll==null)
					iV_Auth_Per_U000011_System_Operation_StartBll=new V_Auth_Per_U000011_System_Operation_StartBLL();
				return iV_Auth_Per_U000011_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U000011_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 380 业务接口
		IV_Auth_Per_U000011_System_Org_TreeBLL iV_Auth_Per_U000011_System_Org_TreeBll;
		public IV_Auth_Per_U000011_System_Org_TreeBLL V_Auth_Per_U000011_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U000011_System_Org_TreeBll==null)
					iV_Auth_Per_U000011_System_Org_TreeBll=new V_Auth_Per_U000011_System_Org_TreeBLL();
				return iV_Auth_Per_U000011_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U000011_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 381 业务接口
		IV_Auth_Per_U000011_System_Person_ReadwriteBLL iV_Auth_Per_U000011_System_Person_ReadwriteBll;
		public IV_Auth_Per_U000011_System_Person_ReadwriteBLL V_Auth_Per_U000011_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U000011_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U000011_System_Person_ReadwriteBll=new V_Auth_Per_U000011_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U000011_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U000011_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 382 业务接口
		IV_Auth_Per_U000011_System_PersonClassBLL iV_Auth_Per_U000011_System_PersonClassBll;
		public IV_Auth_Per_U000011_System_PersonClassBLL V_Auth_Per_U000011_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U000011_System_PersonClassBll==null)
					iV_Auth_Per_U000011_System_PersonClassBll=new V_Auth_Per_U000011_System_PersonClassBLL();
				return iV_Auth_Per_U000011_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U000011_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 383 业务接口
		IV_Auth_Per_U000012_System_BPM_StartBLL iV_Auth_Per_U000012_System_BPM_StartBll;
		public IV_Auth_Per_U000012_System_BPM_StartBLL V_Auth_Per_U000012_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U000012_System_BPM_StartBll==null)
					iV_Auth_Per_U000012_System_BPM_StartBll=new V_Auth_Per_U000012_System_BPM_StartBLL();
				return iV_Auth_Per_U000012_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U000012_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 384 业务接口
		IV_Auth_Per_U000012_System_Operation_StartBLL iV_Auth_Per_U000012_System_Operation_StartBll;
		public IV_Auth_Per_U000012_System_Operation_StartBLL V_Auth_Per_U000012_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U000012_System_Operation_StartBll==null)
					iV_Auth_Per_U000012_System_Operation_StartBll=new V_Auth_Per_U000012_System_Operation_StartBLL();
				return iV_Auth_Per_U000012_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U000012_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 385 业务接口
		IV_Auth_Per_U000012_System_Org_TreeBLL iV_Auth_Per_U000012_System_Org_TreeBll;
		public IV_Auth_Per_U000012_System_Org_TreeBLL V_Auth_Per_U000012_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U000012_System_Org_TreeBll==null)
					iV_Auth_Per_U000012_System_Org_TreeBll=new V_Auth_Per_U000012_System_Org_TreeBLL();
				return iV_Auth_Per_U000012_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U000012_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 386 业务接口
		IV_Auth_Per_U000012_System_Person_ReadwriteBLL iV_Auth_Per_U000012_System_Person_ReadwriteBll;
		public IV_Auth_Per_U000012_System_Person_ReadwriteBLL V_Auth_Per_U000012_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U000012_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U000012_System_Person_ReadwriteBll=new V_Auth_Per_U000012_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U000012_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U000012_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 387 业务接口
		IV_Auth_Per_U000012_System_PersonClassBLL iV_Auth_Per_U000012_System_PersonClassBll;
		public IV_Auth_Per_U000012_System_PersonClassBLL V_Auth_Per_U000012_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U000012_System_PersonClassBll==null)
					iV_Auth_Per_U000012_System_PersonClassBll=new V_Auth_Per_U000012_System_PersonClassBLL();
				return iV_Auth_Per_U000012_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U000012_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 388 业务接口
		IV_Auth_Per_U000014_System_BPM_StartBLL iV_Auth_Per_U000014_System_BPM_StartBll;
		public IV_Auth_Per_U000014_System_BPM_StartBLL V_Auth_Per_U000014_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U000014_System_BPM_StartBll==null)
					iV_Auth_Per_U000014_System_BPM_StartBll=new V_Auth_Per_U000014_System_BPM_StartBLL();
				return iV_Auth_Per_U000014_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U000014_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 389 业务接口
		IV_Auth_Per_U000014_System_Operation_StartBLL iV_Auth_Per_U000014_System_Operation_StartBll;
		public IV_Auth_Per_U000014_System_Operation_StartBLL V_Auth_Per_U000014_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U000014_System_Operation_StartBll==null)
					iV_Auth_Per_U000014_System_Operation_StartBll=new V_Auth_Per_U000014_System_Operation_StartBLL();
				return iV_Auth_Per_U000014_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U000014_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 390 业务接口
		IV_Auth_Per_U000014_System_Org_TreeBLL iV_Auth_Per_U000014_System_Org_TreeBll;
		public IV_Auth_Per_U000014_System_Org_TreeBLL V_Auth_Per_U000014_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U000014_System_Org_TreeBll==null)
					iV_Auth_Per_U000014_System_Org_TreeBll=new V_Auth_Per_U000014_System_Org_TreeBLL();
				return iV_Auth_Per_U000014_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U000014_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 391 业务接口
		IV_Auth_Per_U000014_System_Person_ReadwriteBLL iV_Auth_Per_U000014_System_Person_ReadwriteBll;
		public IV_Auth_Per_U000014_System_Person_ReadwriteBLL V_Auth_Per_U000014_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U000014_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U000014_System_Person_ReadwriteBll=new V_Auth_Per_U000014_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U000014_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U000014_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 392 业务接口
		IV_Auth_Per_U000014_System_PersonClassBLL iV_Auth_Per_U000014_System_PersonClassBll;
		public IV_Auth_Per_U000014_System_PersonClassBLL V_Auth_Per_U000014_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U000014_System_PersonClassBll==null)
					iV_Auth_Per_U000014_System_PersonClassBll=new V_Auth_Per_U000014_System_PersonClassBLL();
				return iV_Auth_Per_U000014_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U000014_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 393 业务接口
		IV_Auth_Per_U000015_System_BPM_StartBLL iV_Auth_Per_U000015_System_BPM_StartBll;
		public IV_Auth_Per_U000015_System_BPM_StartBLL V_Auth_Per_U000015_System_BPM_Start
		{
			get
			{
				if(iV_Auth_Per_U000015_System_BPM_StartBll==null)
					iV_Auth_Per_U000015_System_BPM_StartBll=new V_Auth_Per_U000015_System_BPM_StartBLL();
				return iV_Auth_Per_U000015_System_BPM_StartBll;
			}
			set
			{
				iV_Auth_Per_U000015_System_BPM_StartBll=value;
			}
		}
		#endregion

		#region 394 业务接口
		IV_Auth_Per_U000015_System_Operation_StartBLL iV_Auth_Per_U000015_System_Operation_StartBll;
		public IV_Auth_Per_U000015_System_Operation_StartBLL V_Auth_Per_U000015_System_Operation_Start
		{
			get
			{
				if(iV_Auth_Per_U000015_System_Operation_StartBll==null)
					iV_Auth_Per_U000015_System_Operation_StartBll=new V_Auth_Per_U000015_System_Operation_StartBLL();
				return iV_Auth_Per_U000015_System_Operation_StartBll;
			}
			set
			{
				iV_Auth_Per_U000015_System_Operation_StartBll=value;
			}
		}
		#endregion

		#region 395 业务接口
		IV_Auth_Per_U000015_System_Org_TreeBLL iV_Auth_Per_U000015_System_Org_TreeBll;
		public IV_Auth_Per_U000015_System_Org_TreeBLL V_Auth_Per_U000015_System_Org_Tree
		{
			get
			{
				if(iV_Auth_Per_U000015_System_Org_TreeBll==null)
					iV_Auth_Per_U000015_System_Org_TreeBll=new V_Auth_Per_U000015_System_Org_TreeBLL();
				return iV_Auth_Per_U000015_System_Org_TreeBll;
			}
			set
			{
				iV_Auth_Per_U000015_System_Org_TreeBll=value;
			}
		}
		#endregion

		#region 396 业务接口
		IV_Auth_Per_U000015_System_Person_ReadwriteBLL iV_Auth_Per_U000015_System_Person_ReadwriteBll;
		public IV_Auth_Per_U000015_System_Person_ReadwriteBLL V_Auth_Per_U000015_System_Person_Readwrite
		{
			get
			{
				if(iV_Auth_Per_U000015_System_Person_ReadwriteBll==null)
					iV_Auth_Per_U000015_System_Person_ReadwriteBll=new V_Auth_Per_U000015_System_Person_ReadwriteBLL();
				return iV_Auth_Per_U000015_System_Person_ReadwriteBll;
			}
			set
			{
				iV_Auth_Per_U000015_System_Person_ReadwriteBll=value;
			}
		}
		#endregion

		#region 397 业务接口
		IV_Auth_Per_U000015_System_PersonClassBLL iV_Auth_Per_U000015_System_PersonClassBll;
		public IV_Auth_Per_U000015_System_PersonClassBLL V_Auth_Per_U000015_System_PersonClass
		{
			get
			{
				if(iV_Auth_Per_U000015_System_PersonClassBll==null)
					iV_Auth_Per_U000015_System_PersonClassBll=new V_Auth_Per_U000015_System_PersonClassBLL();
				return iV_Auth_Per_U000015_System_PersonClassBll;
			}
			set
			{
				iV_Auth_Per_U000015_System_PersonClassBll=value;
			}
		}
		#endregion

		#region 398 业务接口
		IV_My_WidgetModule_ObjectsBLL iV_My_WidgetModule_ObjectsBll;
		public IV_My_WidgetModule_ObjectsBLL V_My_WidgetModule_Objects
		{
			get
			{
				if(iV_My_WidgetModule_ObjectsBll==null)
					iV_My_WidgetModule_ObjectsBll=new V_My_WidgetModule_ObjectsBLL();
				return iV_My_WidgetModule_ObjectsBll;
			}
			set
			{
				iV_My_WidgetModule_ObjectsBll=value;
			}
		}
		#endregion

		#region 399 业务接口
		IView_A02BLL iView_A02Bll;
		public IView_A02BLL View_A02
		{
			get
			{
				if(iView_A02Bll==null)
					iView_A02Bll=new View_A02BLL();
				return iView_A02Bll;
			}
			set
			{
				iView_A02Bll=value;
			}
		}
		#endregion

		#region 400 业务接口
		IView_Auth_UserBLL iView_Auth_UserBll;
		public IView_Auth_UserBLL View_Auth_User
		{
			get
			{
				if(iView_Auth_UserBll==null)
					iView_Auth_UserBll=new View_Auth_UserBLL();
				return iView_Auth_UserBll;
			}
			set
			{
				iView_Auth_UserBll=value;
			}
		}
		#endregion

		#region 401 业务接口
		IView_CatalogDocumentBLL iView_CatalogDocumentBll;
		public IView_CatalogDocumentBLL View_CatalogDocument
		{
			get
			{
				if(iView_CatalogDocumentBll==null)
					iView_CatalogDocumentBll=new View_CatalogDocumentBLL();
				return iView_CatalogDocumentBll;
			}
			set
			{
				iView_CatalogDocumentBll=value;
			}
		}
		#endregion

		#region 402 业务接口
		IView_Com_JetTableItemsBLL iView_Com_JetTableItemsBll;
		public IView_Com_JetTableItemsBLL View_Com_JetTableItems
		{
			get
			{
				if(iView_Com_JetTableItemsBll==null)
					iView_Com_JetTableItemsBll=new View_Com_JetTableItemsBLL();
				return iView_Com_JetTableItemsBll;
			}
			set
			{
				iView_Com_JetTableItemsBll=value;
			}
		}
		#endregion

		#region 403 业务接口
		IView_QXTJBLL iView_QXTJBll;
		public IView_QXTJBLL View_QXTJ
		{
			get
			{
				if(iView_QXTJBll==null)
					iView_QXTJBll=new View_QXTJBLL();
				return iView_QXTJBll;
			}
			set
			{
				iView_QXTJBll=value;
			}
		}
		#endregion

		#region 404 业务接口
		IWF_JobMainBLL iWF_JobMainBll;
		public IWF_JobMainBLL WF_JobMain
		{
			get
			{
				if(iWF_JobMainBll==null)
					iWF_JobMainBll=new WF_JobMainBLL();
				return iWF_JobMainBll;
			}
			set
			{
				iWF_JobMainBll=value;
			}
		}
		#endregion

		#region 405 业务接口
		IWF_JobMainExcludeChooseBLL iWF_JobMainExcludeChooseBll;
		public IWF_JobMainExcludeChooseBLL WF_JobMainExcludeChoose
		{
			get
			{
				if(iWF_JobMainExcludeChooseBll==null)
					iWF_JobMainExcludeChooseBll=new WF_JobMainExcludeChooseBLL();
				return iWF_JobMainExcludeChooseBll;
			}
			set
			{
				iWF_JobMainExcludeChooseBll=value;
			}
		}
		#endregion

		#region 406 业务接口
		IWF_JobOpinionBLL iWF_JobOpinionBll;
		public IWF_JobOpinionBLL WF_JobOpinion
		{
			get
			{
				if(iWF_JobOpinionBll==null)
					iWF_JobOpinionBll=new WF_JobOpinionBLL();
				return iWF_JobOpinionBll;
			}
			set
			{
				iWF_JobOpinionBll=value;
			}
		}
		#endregion

		#region 407 业务接口
		IWF_JobProxyBLL iWF_JobProxyBll;
		public IWF_JobProxyBLL WF_JobProxy
		{
			get
			{
				if(iWF_JobProxyBll==null)
					iWF_JobProxyBll=new WF_JobProxyBLL();
				return iWF_JobProxyBll;
			}
			set
			{
				iWF_JobProxyBll=value;
			}
		}
		#endregion

		#region 408 业务接口
		IWF_JobSaveOrgBLL iWF_JobSaveOrgBll;
		public IWF_JobSaveOrgBLL WF_JobSaveOrg
		{
			get
			{
				if(iWF_JobSaveOrgBll==null)
					iWF_JobSaveOrgBll=new WF_JobSaveOrgBLL();
				return iWF_JobSaveOrgBll;
			}
			set
			{
				iWF_JobSaveOrgBll=value;
			}
		}
		#endregion

		#region 409 业务接口
		IWF_JobStepBLL iWF_JobStepBll;
		public IWF_JobStepBLL WF_JobStep
		{
			get
			{
				if(iWF_JobStepBll==null)
					iWF_JobStepBll=new WF_JobStepBLL();
				return iWF_JobStepBll;
			}
			set
			{
				iWF_JobStepBll=value;
			}
		}
		#endregion

		#region 410 业务接口
		IWF_OperationCalcBLL iWF_OperationCalcBll;
		public IWF_OperationCalcBLL WF_OperationCalc
		{
			get
			{
				if(iWF_OperationCalcBll==null)
					iWF_OperationCalcBll=new WF_OperationCalcBLL();
				return iWF_OperationCalcBll;
			}
			set
			{
				iWF_OperationCalcBll=value;
			}
		}
		#endregion

		#region 411 业务接口
		IWF_OperationDocumentBLL iWF_OperationDocumentBll;
		public IWF_OperationDocumentBLL WF_OperationDocument
		{
			get
			{
				if(iWF_OperationDocumentBll==null)
					iWF_OperationDocumentBll=new WF_OperationDocumentBLL();
				return iWF_OperationDocumentBll;
			}
			set
			{
				iWF_OperationDocumentBll=value;
			}
		}
		#endregion

		#region 412 业务接口
		IWF_OperationGroupBLL iWF_OperationGroupBll;
		public IWF_OperationGroupBLL WF_OperationGroup
		{
			get
			{
				if(iWF_OperationGroupBll==null)
					iWF_OperationGroupBll=new WF_OperationGroupBLL();
				return iWF_OperationGroupBll;
			}
			set
			{
				iWF_OperationGroupBll=value;
			}
		}
		#endregion

		#region 413 业务接口
		IWF_OperationKeyValueBLL iWF_OperationKeyValueBll;
		public IWF_OperationKeyValueBLL WF_OperationKeyValue
		{
			get
			{
				if(iWF_OperationKeyValueBll==null)
					iWF_OperationKeyValueBll=new WF_OperationKeyValueBLL();
				return iWF_OperationKeyValueBll;
			}
			set
			{
				iWF_OperationKeyValueBll=value;
			}
		}
		#endregion

		#region 414 业务接口
		IWF_OperationMainBLL iWF_OperationMainBll;
		public IWF_OperationMainBLL WF_OperationMain
		{
			get
			{
				if(iWF_OperationMainBll==null)
					iWF_OperationMainBll=new WF_OperationMainBLL();
				return iWF_OperationMainBll;
			}
			set
			{
				iWF_OperationMainBll=value;
			}
		}
		#endregion

		#region 415 业务接口
		IWF_OperationOutPutBLL iWF_OperationOutPutBll;
		public IWF_OperationOutPutBLL WF_OperationOutPut
		{
			get
			{
				if(iWF_OperationOutPutBll==null)
					iWF_OperationOutPutBll=new WF_OperationOutPutBLL();
				return iWF_OperationOutPutBll;
			}
			set
			{
				iWF_OperationOutPutBll=value;
			}
		}
		#endregion

		#region 416 业务接口
		IWF_OperationSalaryOPItemBLL iWF_OperationSalaryOPItemBll;
		public IWF_OperationSalaryOPItemBLL WF_OperationSalaryOPItem
		{
			get
			{
				if(iWF_OperationSalaryOPItemBll==null)
					iWF_OperationSalaryOPItemBll=new WF_OperationSalaryOPItemBLL();
				return iWF_OperationSalaryOPItemBll;
			}
			set
			{
				iWF_OperationSalaryOPItemBll=value;
			}
		}
		#endregion

		#region 417 业务接口
		IWF_OperationSalaryOPMainBLL iWF_OperationSalaryOPMainBll;
		public IWF_OperationSalaryOPMainBLL WF_OperationSalaryOPMain
		{
			get
			{
				if(iWF_OperationSalaryOPMainBll==null)
					iWF_OperationSalaryOPMainBll=new WF_OperationSalaryOPMainBLL();
				return iWF_OperationSalaryOPMainBll;
			}
			set
			{
				iWF_OperationSalaryOPMainBll=value;
			}
		}
		#endregion

		#region 418 业务接口
		IWF_OperationSalaryOPSignItemBLL iWF_OperationSalaryOPSignItemBll;
		public IWF_OperationSalaryOPSignItemBLL WF_OperationSalaryOPSignItem
		{
			get
			{
				if(iWF_OperationSalaryOPSignItemBll==null)
					iWF_OperationSalaryOPSignItemBll=new WF_OperationSalaryOPSignItemBLL();
				return iWF_OperationSalaryOPSignItemBll;
			}
			set
			{
				iWF_OperationSalaryOPSignItemBll=value;
			}
		}
		#endregion

		#region 419 业务接口
		IWF_OperationSalaryOPSignMainBLL iWF_OperationSalaryOPSignMainBll;
		public IWF_OperationSalaryOPSignMainBLL WF_OperationSalaryOPSignMain
		{
			get
			{
				if(iWF_OperationSalaryOPSignMainBll==null)
					iWF_OperationSalaryOPSignMainBll=new WF_OperationSalaryOPSignMainBLL();
				return iWF_OperationSalaryOPSignMainBll;
			}
			set
			{
				iWF_OperationSalaryOPSignMainBll=value;
			}
		}
		#endregion

		#region 420 业务接口
		IWF_OperationSetItemOptionBLL iWF_OperationSetItemOptionBll;
		public IWF_OperationSetItemOptionBLL WF_OperationSetItemOption
		{
			get
			{
				if(iWF_OperationSetItemOptionBll==null)
					iWF_OperationSetItemOptionBll=new WF_OperationSetItemOptionBLL();
				return iWF_OperationSetItemOptionBll;
			}
			set
			{
				iWF_OperationSetItemOptionBll=value;
			}
		}
		#endregion

		#region 421 业务接口
		IWF_OperationSetItemsBLL iWF_OperationSetItemsBll;
		public IWF_OperationSetItemsBLL WF_OperationSetItems
		{
			get
			{
				if(iWF_OperationSetItemsBll==null)
					iWF_OperationSetItemsBll=new WF_OperationSetItemsBLL();
				return iWF_OperationSetItemsBll;
			}
			set
			{
				iWF_OperationSetItemsBll=value;
			}
		}
		#endregion

		#region 422 业务接口
		IWF_OperationSetTableBLL iWF_OperationSetTableBll;
		public IWF_OperationSetTableBLL WF_OperationSetTable
		{
			get
			{
				if(iWF_OperationSetTableBll==null)
					iWF_OperationSetTableBll=new WF_OperationSetTableBLL();
				return iWF_OperationSetTableBll;
			}
			set
			{
				iWF_OperationSetTableBll=value;
			}
		}
		#endregion

		#region 423 业务接口
		IWF_OperationSetTableOptionBLL iWF_OperationSetTableOptionBll;
		public IWF_OperationSetTableOptionBLL WF_OperationSetTableOption
		{
			get
			{
				if(iWF_OperationSetTableOptionBll==null)
					iWF_OperationSetTableOptionBll=new WF_OperationSetTableOptionBLL();
				return iWF_OperationSetTableOptionBll;
			}
			set
			{
				iWF_OperationSetTableOptionBll=value;
			}
		}
		#endregion

		#region 424 业务接口
		IWF_OperationSTCodeItemsBLL iWF_OperationSTCodeItemsBll;
		public IWF_OperationSTCodeItemsBLL WF_OperationSTCodeItems
		{
			get
			{
				if(iWF_OperationSTCodeItemsBll==null)
					iWF_OperationSTCodeItemsBll=new WF_OperationSTCodeItemsBLL();
				return iWF_OperationSTCodeItemsBll;
			}
			set
			{
				iWF_OperationSTCodeItemsBll=value;
			}
		}
		#endregion

		#region 425 业务接口
		IWF_OperationSTDataBLL iWF_OperationSTDataBll;
		public IWF_OperationSTDataBLL WF_OperationSTData
		{
			get
			{
				if(iWF_OperationSTDataBll==null)
					iWF_OperationSTDataBll=new WF_OperationSTDataBLL();
				return iWF_OperationSTDataBll;
			}
			set
			{
				iWF_OperationSTDataBll=value;
			}
		}
		#endregion

		#region 426 业务接口
		IWF_OperationStepBLL iWF_OperationStepBll;
		public IWF_OperationStepBLL WF_OperationStep
		{
			get
			{
				if(iWF_OperationStepBll==null)
					iWF_OperationStepBll=new WF_OperationStepBLL();
				return iWF_OperationStepBll;
			}
			set
			{
				iWF_OperationStepBll=value;
			}
		}
		#endregion

		#region 427 业务接口
		IWF_OperationStepPrivilegeBLL iWF_OperationStepPrivilegeBll;
		public IWF_OperationStepPrivilegeBLL WF_OperationStepPrivilege
		{
			get
			{
				if(iWF_OperationStepPrivilegeBll==null)
					iWF_OperationStepPrivilegeBll=new WF_OperationStepPrivilegeBLL();
				return iWF_OperationStepPrivilegeBll;
			}
			set
			{
				iWF_OperationStepPrivilegeBll=value;
			}
		}
		#endregion

		#region 428 业务接口
		IWF_OperationSTMainBLL iWF_OperationSTMainBll;
		public IWF_OperationSTMainBLL WF_OperationSTMain
		{
			get
			{
				if(iWF_OperationSTMainBll==null)
					iWF_OperationSTMainBll=new WF_OperationSTMainBLL();
				return iWF_OperationSTMainBll;
			}
			set
			{
				iWF_OperationSTMainBll=value;
			}
		}
		#endregion

		#region 429 业务接口
		IWF_OperationSTSetItemsBLL iWF_OperationSTSetItemsBll;
		public IWF_OperationSTSetItemsBLL WF_OperationSTSetItems
		{
			get
			{
				if(iWF_OperationSTSetItemsBll==null)
					iWF_OperationSTSetItemsBll=new WF_OperationSTSetItemsBLL();
				return iWF_OperationSTSetItemsBll;
			}
			set
			{
				iWF_OperationSTSetItemsBll=value;
			}
		}
		#endregion

		#region 430 业务接口
		IWF_OperationTypeBLL iWF_OperationTypeBll;
		public IWF_OperationTypeBLL WF_OperationType
		{
			get
			{
				if(iWF_OperationTypeBll==null)
					iWF_OperationTypeBll=new WF_OperationTypeBLL();
				return iWF_OperationTypeBll;
			}
			set
			{
				iWF_OperationTypeBll=value;
			}
		}
		#endregion

		#region 431 业务接口
		IWGJG_GRZXBLL iWGJG_GRZXBll;
		public IWGJG_GRZXBLL WGJG_GRZX
		{
			get
			{
				if(iWGJG_GRZXBll==null)
					iWGJG_GRZXBll=new WGJG_GRZXBLL();
				return iWGJG_GRZXBll;
			}
			set
			{
				iWGJG_GRZXBll=value;
			}
		}
		#endregion

		#region 432 业务接口
		IWGJG_WarnDataBLL iWGJG_WarnDataBll;
		public IWGJG_WarnDataBLL WGJG_WarnData
		{
			get
			{
				if(iWGJG_WarnDataBll==null)
					iWGJG_WarnDataBll=new WGJG_WarnDataBLL();
				return iWGJG_WarnDataBll;
			}
			set
			{
				iWGJG_WarnDataBll=value;
			}
		}
		#endregion

		#region 433 业务接口
		IWGJG_ZXBLL iWGJG_ZXBll;
		public IWGJG_ZXBLL WGJG_ZX
		{
			get
			{
				if(iWGJG_ZXBll==null)
					iWGJG_ZXBll=new WGJG_ZXBLL();
				return iWGJG_ZXBll;
			}
			set
			{
				iWGJG_ZXBll=value;
			}
		}
		#endregion

		#region 434 业务接口
		IWGJG01BLL iWGJG01Bll;
		public IWGJG01BLL WGJG01
		{
			get
			{
				if(iWGJG01Bll==null)
					iWGJG01Bll=new WGJG01BLL();
				return iWGJG01Bll;
			}
			set
			{
				iWGJG01Bll=value;
			}
		}
		#endregion

		#region 435 业务接口
		IWGJG01_TemplateBLL iWGJG01_TemplateBll;
		public IWGJG01_TemplateBLL WGJG01_Template
		{
			get
			{
				if(iWGJG01_TemplateBll==null)
					iWGJG01_TemplateBll=new WGJG01_TemplateBLL();
				return iWGJG01_TemplateBll;
			}
			set
			{
				iWGJG01_TemplateBll=value;
			}
		}
		#endregion

		#region 436 业务接口
		IWGJG02BLL iWGJG02Bll;
		public IWGJG02BLL WGJG02
		{
			get
			{
				if(iWGJG02Bll==null)
					iWGJG02Bll=new WGJG02BLL();
				return iWGJG02Bll;
			}
			set
			{
				iWGJG02Bll=value;
			}
		}
		#endregion

		#region 437 业务接口
		IWGJG02_TemplateBLL iWGJG02_TemplateBll;
		public IWGJG02_TemplateBLL WGJG02_Template
		{
			get
			{
				if(iWGJG02_TemplateBll==null)
					iWGJG02_TemplateBll=new WGJG02_TemplateBLL();
				return iWGJG02_TemplateBll;
			}
			set
			{
				iWGJG02_TemplateBll=value;
			}
		}
		#endregion

		#region 438 业务接口
		IXS_StudentBLL iXS_StudentBll;
		public IXS_StudentBLL XS_Student
		{
			get
			{
				if(iXS_StudentBll==null)
					iXS_StudentBll=new XS_StudentBLL();
				return iXS_StudentBll;
			}
			set
			{
				iXS_StudentBll=value;
			}
		}
		#endregion

		#region 439 业务接口
		IXS_StudentScoreBLL iXS_StudentScoreBll;
		public IXS_StudentScoreBLL XS_StudentScore
		{
			get
			{
				if(iXS_StudentScoreBll==null)
					iXS_StudentScoreBll=new XS_StudentScoreBLL();
				return iXS_StudentScoreBll;
			}
			set
			{
				iXS_StudentScoreBll=value;
			}
		}
		#endregion

		}
}