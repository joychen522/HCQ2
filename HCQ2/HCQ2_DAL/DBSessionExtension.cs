
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCQ2_IDAL;
namespace HCQ2_DAL_MSSQL
{
	public partial class DBSession
	{
		#region 01 数据接口
		IA01DAL iA01DAL;
		public IA01DAL IA01DAL
		{
			get
			{
				if(iA01DAL==null)
					iA01DAL=new A01DAL();
				return iA01DAL;
			}
			set
			{
				iA01DAL=value;
			}
		}
		#endregion
			#region 02 数据接口
		IA02DAL iA02DAL;
		public IA02DAL IA02DAL
		{
			get
			{
				if(iA02DAL==null)
					iA02DAL=new A02DAL();
				return iA02DAL;
			}
			set
			{
				iA02DAL=value;
			}
		}
		#endregion
			#region 03 数据接口
		IA03DAL iA03DAL;
		public IA03DAL IA03DAL
		{
			get
			{
				if(iA03DAL==null)
					iA03DAL=new A03DAL();
				return iA03DAL;
			}
			set
			{
				iA03DAL=value;
			}
		}
		#endregion
			#region 04 数据接口
		IA04DAL iA04DAL;
		public IA04DAL IA04DAL
		{
			get
			{
				if(iA04DAL==null)
					iA04DAL=new A04DAL();
				return iA04DAL;
			}
			set
			{
				iA04DAL=value;
			}
		}
		#endregion
			#region 05 数据接口
		IA19DAL iA19DAL;
		public IA19DAL IA19DAL
		{
			get
			{
				if(iA19DAL==null)
					iA19DAL=new A19DAL();
				return iA19DAL;
			}
			set
			{
				iA19DAL=value;
			}
		}
		#endregion
			#region 06 数据接口
		IATTACHJOBDAL iATTACHJOBDAL;
		public IATTACHJOBDAL IATTACHJOBDAL
		{
			get
			{
				if(iATTACHJOBDAL==null)
					iATTACHJOBDAL=new ATTACHJOBDAL();
				return iATTACHJOBDAL;
			}
			set
			{
				iATTACHJOBDAL=value;
			}
		}
		#endregion
			#region 07 数据接口
		IAuth_Define_DataScopeDAL iAuth_Define_DataScopeDAL;
		public IAuth_Define_DataScopeDAL IAuth_Define_DataScopeDAL
		{
			get
			{
				if(iAuth_Define_DataScopeDAL==null)
					iAuth_Define_DataScopeDAL=new Auth_Define_DataScopeDAL();
				return iAuth_Define_DataScopeDAL;
			}
			set
			{
				iAuth_Define_DataScopeDAL=value;
			}
		}
		#endregion
			#region 08 数据接口
		IAuth_Define_DataScopeItemDAL iAuth_Define_DataScopeItemDAL;
		public IAuth_Define_DataScopeItemDAL IAuth_Define_DataScopeItemDAL
		{
			get
			{
				if(iAuth_Define_DataScopeItemDAL==null)
					iAuth_Define_DataScopeItemDAL=new Auth_Define_DataScopeItemDAL();
				return iAuth_Define_DataScopeItemDAL;
			}
			set
			{
				iAuth_Define_DataScopeItemDAL=value;
			}
		}
		#endregion
			#region 09 数据接口
		IAuth_Define_FuncDAL iAuth_Define_FuncDAL;
		public IAuth_Define_FuncDAL IAuth_Define_FuncDAL
		{
			get
			{
				if(iAuth_Define_FuncDAL==null)
					iAuth_Define_FuncDAL=new Auth_Define_FuncDAL();
				return iAuth_Define_FuncDAL;
			}
			set
			{
				iAuth_Define_FuncDAL=value;
			}
		}
		#endregion
			#region 10 数据接口
		IAuth_Define_SetDBDAL iAuth_Define_SetDBDAL;
		public IAuth_Define_SetDBDAL IAuth_Define_SetDBDAL
		{
			get
			{
				if(iAuth_Define_SetDBDAL==null)
					iAuth_Define_SetDBDAL=new Auth_Define_SetDBDAL();
				return iAuth_Define_SetDBDAL;
			}
			set
			{
				iAuth_Define_SetDBDAL=value;
			}
		}
		#endregion
			#region 11 数据接口
		IAuth_Define_SetItemDAL iAuth_Define_SetItemDAL;
		public IAuth_Define_SetItemDAL IAuth_Define_SetItemDAL
		{
			get
			{
				if(iAuth_Define_SetItemDAL==null)
					iAuth_Define_SetItemDAL=new Auth_Define_SetItemDAL();
				return iAuth_Define_SetItemDAL;
			}
			set
			{
				iAuth_Define_SetItemDAL=value;
			}
		}
		#endregion
			#region 12 数据接口
		IAuth_Define_SetTableDAL iAuth_Define_SetTableDAL;
		public IAuth_Define_SetTableDAL IAuth_Define_SetTableDAL
		{
			get
			{
				if(iAuth_Define_SetTableDAL==null)
					iAuth_Define_SetTableDAL=new Auth_Define_SetTableDAL();
				return iAuth_Define_SetTableDAL;
			}
			set
			{
				iAuth_Define_SetTableDAL=value;
			}
		}
		#endregion
			#region 13 数据接口
		IAuth_OrgRoleDAL iAuth_OrgRoleDAL;
		public IAuth_OrgRoleDAL IAuth_OrgRoleDAL
		{
			get
			{
				if(iAuth_OrgRoleDAL==null)
					iAuth_OrgRoleDAL=new Auth_OrgRoleDAL();
				return iAuth_OrgRoleDAL;
			}
			set
			{
				iAuth_OrgRoleDAL=value;
			}
		}
		#endregion
			#region 14 数据接口
		IAuth_PermissionDAL iAuth_PermissionDAL;
		public IAuth_PermissionDAL IAuth_PermissionDAL
		{
			get
			{
				if(iAuth_PermissionDAL==null)
					iAuth_PermissionDAL=new Auth_PermissionDAL();
				return iAuth_PermissionDAL;
			}
			set
			{
				iAuth_PermissionDAL=value;
			}
		}
		#endregion
			#region 15 数据接口
		IAuth_PermissionScopeDAL iAuth_PermissionScopeDAL;
		public IAuth_PermissionScopeDAL IAuth_PermissionScopeDAL
		{
			get
			{
				if(iAuth_PermissionScopeDAL==null)
					iAuth_PermissionScopeDAL=new Auth_PermissionScopeDAL();
				return iAuth_PermissionScopeDAL;
			}
			set
			{
				iAuth_PermissionScopeDAL=value;
			}
		}
		#endregion
			#region 16 数据接口
		IAuth_RoleDAL iAuth_RoleDAL;
		public IAuth_RoleDAL IAuth_RoleDAL
		{
			get
			{
				if(iAuth_RoleDAL==null)
					iAuth_RoleDAL=new Auth_RoleDAL();
				return iAuth_RoleDAL;
			}
			set
			{
				iAuth_RoleDAL=value;
			}
		}
		#endregion
			#region 17 数据接口
		IAuth_SecretLoginDAL iAuth_SecretLoginDAL;
		public IAuth_SecretLoginDAL IAuth_SecretLoginDAL
		{
			get
			{
				if(iAuth_SecretLoginDAL==null)
					iAuth_SecretLoginDAL=new Auth_SecretLoginDAL();
				return iAuth_SecretLoginDAL;
			}
			set
			{
				iAuth_SecretLoginDAL=value;
			}
		}
		#endregion
			#region 18 数据接口
		IAuth_UserDAL iAuth_UserDAL;
		public IAuth_UserDAL IAuth_UserDAL
		{
			get
			{
				if(iAuth_UserDAL==null)
					iAuth_UserDAL=new Auth_UserDAL();
				return iAuth_UserDAL;
			}
			set
			{
				iAuth_UserDAL=value;
			}
		}
		#endregion
			#region 19 数据接口
		IAuth_UserGroupDAL iAuth_UserGroupDAL;
		public IAuth_UserGroupDAL IAuth_UserGroupDAL
		{
			get
			{
				if(iAuth_UserGroupDAL==null)
					iAuth_UserGroupDAL=new Auth_UserGroupDAL();
				return iAuth_UserGroupDAL;
			}
			set
			{
				iAuth_UserGroupDAL=value;
			}
		}
		#endregion
			#region 20 数据接口
		IAuth_UserGroupRoleDAL iAuth_UserGroupRoleDAL;
		public IAuth_UserGroupRoleDAL IAuth_UserGroupRoleDAL
		{
			get
			{
				if(iAuth_UserGroupRoleDAL==null)
					iAuth_UserGroupRoleDAL=new Auth_UserGroupRoleDAL();
				return iAuth_UserGroupRoleDAL;
			}
			set
			{
				iAuth_UserGroupRoleDAL=value;
			}
		}
		#endregion
			#region 21 数据接口
		IAuth_UserLogonDAL iAuth_UserLogonDAL;
		public IAuth_UserLogonDAL IAuth_UserLogonDAL
		{
			get
			{
				if(iAuth_UserLogonDAL==null)
					iAuth_UserLogonDAL=new Auth_UserLogonDAL();
				return iAuth_UserLogonDAL;
			}
			set
			{
				iAuth_UserLogonDAL=value;
			}
		}
		#endregion
			#region 22 数据接口
		IAuth_UserRoleDAL iAuth_UserRoleDAL;
		public IAuth_UserRoleDAL IAuth_UserRoleDAL
		{
			get
			{
				if(iAuth_UserRoleDAL==null)
					iAuth_UserRoleDAL=new Auth_UserRoleDAL();
				return iAuth_UserRoleDAL;
			}
			set
			{
				iAuth_UserRoleDAL=value;
			}
		}
		#endregion
			#region 23 数据接口
		IAuth_UserWeixinDAL iAuth_UserWeixinDAL;
		public IAuth_UserWeixinDAL IAuth_UserWeixinDAL
		{
			get
			{
				if(iAuth_UserWeixinDAL==null)
					iAuth_UserWeixinDAL=new Auth_UserWeixinDAL();
				return iAuth_UserWeixinDAL;
			}
			set
			{
				iAuth_UserWeixinDAL=value;
			}
		}
		#endregion
			#region 24 数据接口
		IB01DAL iB01DAL;
		public IB01DAL IB01DAL
		{
			get
			{
				if(iB01DAL==null)
					iB01DAL=new B01DAL();
				return iB01DAL;
			}
			set
			{
				iB01DAL=value;
			}
		}
		#endregion
			#region 25 数据接口
		IBB_CashDetailDAL iBB_CashDetailDAL;
		public IBB_CashDetailDAL IBB_CashDetailDAL
		{
			get
			{
				if(iBB_CashDetailDAL==null)
					iBB_CashDetailDAL=new BB_CashDetailDAL();
				return iBB_CashDetailDAL;
			}
			set
			{
				iBB_CashDetailDAL=value;
			}
		}
		#endregion
			#region 26 数据接口
		IBB_DWDAL iBB_DWDAL;
		public IBB_DWDAL IBB_DWDAL
		{
			get
			{
				if(iBB_DWDAL==null)
					iBB_DWDAL=new BB_DWDAL();
				return iBB_DWDAL;
			}
			set
			{
				iBB_DWDAL=value;
			}
		}
		#endregion
			#region 27 数据接口
		IBB_DWLevelDAL iBB_DWLevelDAL;
		public IBB_DWLevelDAL IBB_DWLevelDAL
		{
			get
			{
				if(iBB_DWLevelDAL==null)
					iBB_DWLevelDAL=new BB_DWLevelDAL();
				return iBB_DWLevelDAL;
			}
			set
			{
				iBB_DWLevelDAL=value;
			}
		}
		#endregion
			#region 28 数据接口
		IBB_DWLevelUserDAL iBB_DWLevelUserDAL;
		public IBB_DWLevelUserDAL IBB_DWLevelUserDAL
		{
			get
			{
				if(iBB_DWLevelUserDAL==null)
					iBB_DWLevelUserDAL=new BB_DWLevelUserDAL();
				return iBB_DWLevelUserDAL;
			}
			set
			{
				iBB_DWLevelUserDAL=value;
			}
		}
		#endregion
			#region 29 数据接口
		IBB_DWStateDAL iBB_DWStateDAL;
		public IBB_DWStateDAL IBB_DWStateDAL
		{
			get
			{
				if(iBB_DWStateDAL==null)
					iBB_DWStateDAL=new BB_DWStateDAL();
				return iBB_DWStateDAL;
			}
			set
			{
				iBB_DWStateDAL=value;
			}
		}
		#endregion
			#region 30 数据接口
		IBB_DWStateCheckResultDAL iBB_DWStateCheckResultDAL;
		public IBB_DWStateCheckResultDAL IBB_DWStateCheckResultDAL
		{
			get
			{
				if(iBB_DWStateCheckResultDAL==null)
					iBB_DWStateCheckResultDAL=new BB_DWStateCheckResultDAL();
				return iBB_DWStateCheckResultDAL;
			}
			set
			{
				iBB_DWStateCheckResultDAL=value;
			}
		}
		#endregion
			#region 31 数据接口
		IBB_DWTotalDAL iBB_DWTotalDAL;
		public IBB_DWTotalDAL IBB_DWTotalDAL
		{
			get
			{
				if(iBB_DWTotalDAL==null)
					iBB_DWTotalDAL=new BB_DWTotalDAL();
				return iBB_DWTotalDAL;
			}
			set
			{
				iBB_DWTotalDAL=value;
			}
		}
		#endregion
			#region 32 数据接口
		IBB_FacilityPreserveDAL iBB_FacilityPreserveDAL;
		public IBB_FacilityPreserveDAL IBB_FacilityPreserveDAL
		{
			get
			{
				if(iBB_FacilityPreserveDAL==null)
					iBB_FacilityPreserveDAL=new BB_FacilityPreserveDAL();
				return iBB_FacilityPreserveDAL;
			}
			set
			{
				iBB_FacilityPreserveDAL=value;
			}
		}
		#endregion
			#region 33 数据接口
		IBB_FetchDataSetupDAL iBB_FetchDataSetupDAL;
		public IBB_FetchDataSetupDAL IBB_FetchDataSetupDAL
		{
			get
			{
				if(iBB_FetchDataSetupDAL==null)
					iBB_FetchDataSetupDAL=new BB_FetchDataSetupDAL();
				return iBB_FetchDataSetupDAL;
			}
			set
			{
				iBB_FetchDataSetupDAL=value;
			}
		}
		#endregion
			#region 34 数据接口
		IBB_FetchFCDAL iBB_FetchFCDAL;
		public IBB_FetchFCDAL IBB_FetchFCDAL
		{
			get
			{
				if(iBB_FetchFCDAL==null)
					iBB_FetchFCDAL=new BB_FetchFCDAL();
				return iBB_FetchFCDAL;
			}
			set
			{
				iBB_FetchFCDAL=value;
			}
		}
		#endregion
			#region 35 数据接口
		IBB_FetchNumberFuncDAL iBB_FetchNumberFuncDAL;
		public IBB_FetchNumberFuncDAL IBB_FetchNumberFuncDAL
		{
			get
			{
				if(iBB_FetchNumberFuncDAL==null)
					iBB_FetchNumberFuncDAL=new BB_FetchNumberFuncDAL();
				return iBB_FetchNumberFuncDAL;
			}
			set
			{
				iBB_FetchNumberFuncDAL=value;
			}
		}
		#endregion
			#region 36 数据接口
		IBB_FetchPoolLogDAL iBB_FetchPoolLogDAL;
		public IBB_FetchPoolLogDAL IBB_FetchPoolLogDAL
		{
			get
			{
				if(iBB_FetchPoolLogDAL==null)
					iBB_FetchPoolLogDAL=new BB_FetchPoolLogDAL();
				return iBB_FetchPoolLogDAL;
			}
			set
			{
				iBB_FetchPoolLogDAL=value;
			}
		}
		#endregion
			#region 37 数据接口
		IBB_InternalReciveLogDAL iBB_InternalReciveLogDAL;
		public IBB_InternalReciveLogDAL IBB_InternalReciveLogDAL
		{
			get
			{
				if(iBB_InternalReciveLogDAL==null)
					iBB_InternalReciveLogDAL=new BB_InternalReciveLogDAL();
				return iBB_InternalReciveLogDAL;
			}
			set
			{
				iBB_InternalReciveLogDAL=value;
			}
		}
		#endregion
			#region 38 数据接口
		IBB_InternalSendDAL iBB_InternalSendDAL;
		public IBB_InternalSendDAL IBB_InternalSendDAL
		{
			get
			{
				if(iBB_InternalSendDAL==null)
					iBB_InternalSendDAL=new BB_InternalSendDAL();
				return iBB_InternalSendDAL;
			}
			set
			{
				iBB_InternalSendDAL=value;
			}
		}
		#endregion
			#region 39 数据接口
		IBB_ItemPreserveDAL iBB_ItemPreserveDAL;
		public IBB_ItemPreserveDAL IBB_ItemPreserveDAL
		{
			get
			{
				if(iBB_ItemPreserveDAL==null)
					iBB_ItemPreserveDAL=new BB_ItemPreserveDAL();
				return iBB_ItemPreserveDAL;
			}
			set
			{
				iBB_ItemPreserveDAL=value;
			}
		}
		#endregion
			#region 40 数据接口
		IBB_PactDetailFlieDAL iBB_PactDetailFlieDAL;
		public IBB_PactDetailFlieDAL IBB_PactDetailFlieDAL
		{
			get
			{
				if(iBB_PactDetailFlieDAL==null)
					iBB_PactDetailFlieDAL=new BB_PactDetailFlieDAL();
				return iBB_PactDetailFlieDAL;
			}
			set
			{
				iBB_PactDetailFlieDAL=value;
			}
		}
		#endregion
			#region 41 数据接口
		IBB_ServiceUserDAL iBB_ServiceUserDAL;
		public IBB_ServiceUserDAL IBB_ServiceUserDAL
		{
			get
			{
				if(iBB_ServiceUserDAL==null)
					iBB_ServiceUserDAL=new BB_ServiceUserDAL();
				return iBB_ServiceUserDAL;
			}
			set
			{
				iBB_ServiceUserDAL=value;
			}
		}
		#endregion
			#region 42 数据接口
		IBB_SJ_DataSpecialDAL iBB_SJ_DataSpecialDAL;
		public IBB_SJ_DataSpecialDAL IBB_SJ_DataSpecialDAL
		{
			get
			{
				if(iBB_SJ_DataSpecialDAL==null)
					iBB_SJ_DataSpecialDAL=new BB_SJ_DataSpecialDAL();
				return iBB_SJ_DataSpecialDAL;
			}
			set
			{
				iBB_SJ_DataSpecialDAL=value;
			}
		}
		#endregion
			#region 43 数据接口
		IBB_SJ_NoteFloatDAL iBB_SJ_NoteFloatDAL;
		public IBB_SJ_NoteFloatDAL IBB_SJ_NoteFloatDAL
		{
			get
			{
				if(iBB_SJ_NoteFloatDAL==null)
					iBB_SJ_NoteFloatDAL=new BB_SJ_NoteFloatDAL();
				return iBB_SJ_NoteFloatDAL;
			}
			set
			{
				iBB_SJ_NoteFloatDAL=value;
			}
		}
		#endregion
			#region 44 数据接口
		IBB_SJ_NoteTextDAL iBB_SJ_NoteTextDAL;
		public IBB_SJ_NoteTextDAL IBB_SJ_NoteTextDAL
		{
			get
			{
				if(iBB_SJ_NoteTextDAL==null)
					iBB_SJ_NoteTextDAL=new BB_SJ_NoteTextDAL();
				return iBB_SJ_NoteTextDAL;
			}
			set
			{
				iBB_SJ_NoteTextDAL=value;
			}
		}
		#endregion
			#region 45 数据接口
		IBB_TBDAL iBB_TBDAL;
		public IBB_TBDAL IBB_TBDAL
		{
			get
			{
				if(iBB_TBDAL==null)
					iBB_TBDAL=new BB_TBDAL();
				return iBB_TBDAL;
			}
			set
			{
				iBB_TBDAL=value;
			}
		}
		#endregion
			#region 46 数据接口
		IBB_TBClassDAL iBB_TBClassDAL;
		public IBB_TBClassDAL IBB_TBClassDAL
		{
			get
			{
				if(iBB_TBClassDAL==null)
					iBB_TBClassDAL=new BB_TBClassDAL();
				return iBB_TBClassDAL;
			}
			set
			{
				iBB_TBClassDAL=value;
			}
		}
		#endregion
			#region 47 数据接口
		IBB_TBDataHintDAL iBB_TBDataHintDAL;
		public IBB_TBDataHintDAL IBB_TBDataHintDAL
		{
			get
			{
				if(iBB_TBDataHintDAL==null)
					iBB_TBDataHintDAL=new BB_TBDataHintDAL();
				return iBB_TBDataHintDAL;
			}
			set
			{
				iBB_TBDataHintDAL=value;
			}
		}
		#endregion
			#region 48 数据接口
		IBB_TBItemsDAL iBB_TBItemsDAL;
		public IBB_TBItemsDAL IBB_TBItemsDAL
		{
			get
			{
				if(iBB_TBItemsDAL==null)
					iBB_TBItemsDAL=new BB_TBItemsDAL();
				return iBB_TBItemsDAL;
			}
			set
			{
				iBB_TBItemsDAL=value;
			}
		}
		#endregion
			#region 49 数据接口
		IBB_TBRemarkUserLevelDAL iBB_TBRemarkUserLevelDAL;
		public IBB_TBRemarkUserLevelDAL IBB_TBRemarkUserLevelDAL
		{
			get
			{
				if(iBB_TBRemarkUserLevelDAL==null)
					iBB_TBRemarkUserLevelDAL=new BB_TBRemarkUserLevelDAL();
				return iBB_TBRemarkUserLevelDAL;
			}
			set
			{
				iBB_TBRemarkUserLevelDAL=value;
			}
		}
		#endregion
			#region 50 数据接口
		IBB_TBRemarkUsersDAL iBB_TBRemarkUsersDAL;
		public IBB_TBRemarkUsersDAL IBB_TBRemarkUsersDAL
		{
			get
			{
				if(iBB_TBRemarkUsersDAL==null)
					iBB_TBRemarkUsersDAL=new BB_TBRemarkUsersDAL();
				return iBB_TBRemarkUsersDAL;
			}
			set
			{
				iBB_TBRemarkUsersDAL=value;
			}
		}
		#endregion
			#region 51 数据接口
		IBB_TotalFCDAL iBB_TotalFCDAL;
		public IBB_TotalFCDAL IBB_TotalFCDAL
		{
			get
			{
				if(iBB_TotalFCDAL==null)
					iBB_TotalFCDAL=new BB_TotalFCDAL();
				return iBB_TotalFCDAL;
			}
			set
			{
				iBB_TotalFCDAL=value;
			}
		}
		#endregion
			#region 52 数据接口
		IBB_TrackRecordDAL iBB_TrackRecordDAL;
		public IBB_TrackRecordDAL IBB_TrackRecordDAL
		{
			get
			{
				if(iBB_TrackRecordDAL==null)
					iBB_TrackRecordDAL=new BB_TrackRecordDAL();
				return iBB_TrackRecordDAL;
			}
			set
			{
				iBB_TrackRecordDAL=value;
			}
		}
		#endregion
			#region 53 数据接口
		IBB_TypeDAL iBB_TypeDAL;
		public IBB_TypeDAL IBB_TypeDAL
		{
			get
			{
				if(iBB_TypeDAL==null)
					iBB_TypeDAL=new BB_TypeDAL();
				return iBB_TypeDAL;
			}
			set
			{
				iBB_TypeDAL=value;
			}
		}
		#endregion
			#region 54 数据接口
		IBB_TypeCycleDAL iBB_TypeCycleDAL;
		public IBB_TypeCycleDAL IBB_TypeCycleDAL
		{
			get
			{
				if(iBB_TypeCycleDAL==null)
					iBB_TypeCycleDAL=new BB_TypeCycleDAL();
				return iBB_TypeCycleDAL;
			}
			set
			{
				iBB_TypeCycleDAL=value;
			}
		}
		#endregion
			#region 55 数据接口
		IBB_UpDataLogDAL iBB_UpDataLogDAL;
		public IBB_UpDataLogDAL IBB_UpDataLogDAL
		{
			get
			{
				if(iBB_UpDataLogDAL==null)
					iBB_UpDataLogDAL=new BB_UpDataLogDAL();
				return iBB_UpDataLogDAL;
			}
			set
			{
				iBB_UpDataLogDAL=value;
			}
		}
		#endregion
			#region 56 数据接口
		IBB_ZBDAL iBB_ZBDAL;
		public IBB_ZBDAL IBB_ZBDAL
		{
			get
			{
				if(iBB_ZBDAL==null)
					iBB_ZBDAL=new BB_ZBDAL();
				return iBB_ZBDAL;
			}
			set
			{
				iBB_ZBDAL=value;
			}
		}
		#endregion
			#region 57 数据接口
		IBB_ZBConditionDAL iBB_ZBConditionDAL;
		public IBB_ZBConditionDAL IBB_ZBConditionDAL
		{
			get
			{
				if(iBB_ZBConditionDAL==null)
					iBB_ZBConditionDAL=new BB_ZBConditionDAL();
				return iBB_ZBConditionDAL;
			}
			set
			{
				iBB_ZBConditionDAL=value;
			}
		}
		#endregion
			#region 58 数据接口
		IBB_ZBVarItemsDAL iBB_ZBVarItemsDAL;
		public IBB_ZBVarItemsDAL IBB_ZBVarItemsDAL
		{
			get
			{
				if(iBB_ZBVarItemsDAL==null)
					iBB_ZBVarItemsDAL=new BB_ZBVarItemsDAL();
				return iBB_ZBVarItemsDAL;
			}
			set
			{
				iBB_ZBVarItemsDAL=value;
			}
		}
		#endregion
			#region 59 数据接口
		IBMQ_DocumentDAL iBMQ_DocumentDAL;
		public IBMQ_DocumentDAL IBMQ_DocumentDAL
		{
			get
			{
				if(iBMQ_DocumentDAL==null)
					iBMQ_DocumentDAL=new BMQ_DocumentDAL();
				return iBMQ_DocumentDAL;
			}
			set
			{
				iBMQ_DocumentDAL=value;
			}
		}
		#endregion
			#region 60 数据接口
		IBPM_AgencyRuleDAL iBPM_AgencyRuleDAL;
		public IBPM_AgencyRuleDAL IBPM_AgencyRuleDAL
		{
			get
			{
				if(iBPM_AgencyRuleDAL==null)
					iBPM_AgencyRuleDAL=new BPM_AgencyRuleDAL();
				return iBPM_AgencyRuleDAL;
			}
			set
			{
				iBPM_AgencyRuleDAL=value;
			}
		}
		#endregion
			#region 61 数据接口
		IBPM_AgencyRuleAssigneeDAL iBPM_AgencyRuleAssigneeDAL;
		public IBPM_AgencyRuleAssigneeDAL IBPM_AgencyRuleAssigneeDAL
		{
			get
			{
				if(iBPM_AgencyRuleAssigneeDAL==null)
					iBPM_AgencyRuleAssigneeDAL=new BPM_AgencyRuleAssigneeDAL();
				return iBPM_AgencyRuleAssigneeDAL;
			}
			set
			{
				iBPM_AgencyRuleAssigneeDAL=value;
			}
		}
		#endregion
			#region 62 数据接口
		IBPM_AgencyRuleProcessDAL iBPM_AgencyRuleProcessDAL;
		public IBPM_AgencyRuleProcessDAL IBPM_AgencyRuleProcessDAL
		{
			get
			{
				if(iBPM_AgencyRuleProcessDAL==null)
					iBPM_AgencyRuleProcessDAL=new BPM_AgencyRuleProcessDAL();
				return iBPM_AgencyRuleProcessDAL;
			}
			set
			{
				iBPM_AgencyRuleProcessDAL=value;
			}
		}
		#endregion
			#region 63 数据接口
		IBPM_D_AskForLeaveDemo_MainDAL iBPM_D_AskForLeaveDemo_MainDAL;
		public IBPM_D_AskForLeaveDemo_MainDAL IBPM_D_AskForLeaveDemo_MainDAL
		{
			get
			{
				if(iBPM_D_AskForLeaveDemo_MainDAL==null)
					iBPM_D_AskForLeaveDemo_MainDAL=new BPM_D_AskForLeaveDemo_MainDAL();
				return iBPM_D_AskForLeaveDemo_MainDAL;
			}
			set
			{
				iBPM_D_AskForLeaveDemo_MainDAL=value;
			}
		}
		#endregion
			#region 64 数据接口
		IBPM_D_Leave_MainDAL iBPM_D_Leave_MainDAL;
		public IBPM_D_Leave_MainDAL IBPM_D_Leave_MainDAL
		{
			get
			{
				if(iBPM_D_Leave_MainDAL==null)
					iBPM_D_Leave_MainDAL=new BPM_D_Leave_MainDAL();
				return iBPM_D_Leave_MainDAL;
			}
			set
			{
				iBPM_D_Leave_MainDAL=value;
			}
		}
		#endregion
			#region 65 数据接口
		IBPM_D_NewEmployees_MainDAL iBPM_D_NewEmployees_MainDAL;
		public IBPM_D_NewEmployees_MainDAL IBPM_D_NewEmployees_MainDAL
		{
			get
			{
				if(iBPM_D_NewEmployees_MainDAL==null)
					iBPM_D_NewEmployees_MainDAL=new BPM_D_NewEmployees_MainDAL();
				return iBPM_D_NewEmployees_MainDAL;
			}
			set
			{
				iBPM_D_NewEmployees_MainDAL=value;
			}
		}
		#endregion
			#region 66 数据接口
		IBPM_Define_ActionListenerDAL iBPM_Define_ActionListenerDAL;
		public IBPM_Define_ActionListenerDAL IBPM_Define_ActionListenerDAL
		{
			get
			{
				if(iBPM_Define_ActionListenerDAL==null)
					iBPM_Define_ActionListenerDAL=new BPM_Define_ActionListenerDAL();
				return iBPM_Define_ActionListenerDAL;
			}
			set
			{
				iBPM_Define_ActionListenerDAL=value;
			}
		}
		#endregion
			#region 67 数据接口
		IBPM_Define_ActorAdapterDAL iBPM_Define_ActorAdapterDAL;
		public IBPM_Define_ActorAdapterDAL IBPM_Define_ActorAdapterDAL
		{
			get
			{
				if(iBPM_Define_ActorAdapterDAL==null)
					iBPM_Define_ActorAdapterDAL=new BPM_Define_ActorAdapterDAL();
				return iBPM_Define_ActorAdapterDAL;
			}
			set
			{
				iBPM_Define_ActorAdapterDAL=value;
			}
		}
		#endregion
			#region 68 数据接口
		IBPM_Define_ActorAdapter_bakDAL iBPM_Define_ActorAdapter_bakDAL;
		public IBPM_Define_ActorAdapter_bakDAL IBPM_Define_ActorAdapter_bakDAL
		{
			get
			{
				if(iBPM_Define_ActorAdapter_bakDAL==null)
					iBPM_Define_ActorAdapter_bakDAL=new BPM_Define_ActorAdapter_bakDAL();
				return iBPM_Define_ActorAdapter_bakDAL;
			}
			set
			{
				iBPM_Define_ActorAdapter_bakDAL=value;
			}
		}
		#endregion
			#region 69 数据接口
		IBPM_Define_CatalogDAL iBPM_Define_CatalogDAL;
		public IBPM_Define_CatalogDAL IBPM_Define_CatalogDAL
		{
			get
			{
				if(iBPM_Define_CatalogDAL==null)
					iBPM_Define_CatalogDAL=new BPM_Define_CatalogDAL();
				return iBPM_Define_CatalogDAL;
			}
			set
			{
				iBPM_Define_CatalogDAL=value;
			}
		}
		#endregion
			#region 70 数据接口
		IBPM_Define_ConstDAL iBPM_Define_ConstDAL;
		public IBPM_Define_ConstDAL IBPM_Define_ConstDAL
		{
			get
			{
				if(iBPM_Define_ConstDAL==null)
					iBPM_Define_ConstDAL=new BPM_Define_ConstDAL();
				return iBPM_Define_ConstDAL;
			}
			set
			{
				iBPM_Define_ConstDAL=value;
			}
		}
		#endregion
			#region 71 数据接口
		IBPM_Define_DataModelDAL iBPM_Define_DataModelDAL;
		public IBPM_Define_DataModelDAL IBPM_Define_DataModelDAL
		{
			get
			{
				if(iBPM_Define_DataModelDAL==null)
					iBPM_Define_DataModelDAL=new BPM_Define_DataModelDAL();
				return iBPM_Define_DataModelDAL;
			}
			set
			{
				iBPM_Define_DataModelDAL=value;
			}
		}
		#endregion
			#region 72 数据接口
		IBPM_Define_FormDAL iBPM_Define_FormDAL;
		public IBPM_Define_FormDAL IBPM_Define_FormDAL
		{
			get
			{
				if(iBPM_Define_FormDAL==null)
					iBPM_Define_FormDAL=new BPM_Define_FormDAL();
				return iBPM_Define_FormDAL;
			}
			set
			{
				iBPM_Define_FormDAL=value;
			}
		}
		#endregion
			#region 73 数据接口
		IBPM_Define_PackageDAL iBPM_Define_PackageDAL;
		public IBPM_Define_PackageDAL IBPM_Define_PackageDAL
		{
			get
			{
				if(iBPM_Define_PackageDAL==null)
					iBPM_Define_PackageDAL=new BPM_Define_PackageDAL();
				return iBPM_Define_PackageDAL;
			}
			set
			{
				iBPM_Define_PackageDAL=value;
			}
		}
		#endregion
			#region 74 数据接口
		IBPM_Define_ProcessDraftDAL iBPM_Define_ProcessDraftDAL;
		public IBPM_Define_ProcessDraftDAL IBPM_Define_ProcessDraftDAL
		{
			get
			{
				if(iBPM_Define_ProcessDraftDAL==null)
					iBPM_Define_ProcessDraftDAL=new BPM_Define_ProcessDraftDAL();
				return iBPM_Define_ProcessDraftDAL;
			}
			set
			{
				iBPM_Define_ProcessDraftDAL=value;
			}
		}
		#endregion
			#region 75 数据接口
		IBPM_Define_ProcessPublishedDAL iBPM_Define_ProcessPublishedDAL;
		public IBPM_Define_ProcessPublishedDAL IBPM_Define_ProcessPublishedDAL
		{
			get
			{
				if(iBPM_Define_ProcessPublishedDAL==null)
					iBPM_Define_ProcessPublishedDAL=new BPM_Define_ProcessPublishedDAL();
				return iBPM_Define_ProcessPublishedDAL;
			}
			set
			{
				iBPM_Define_ProcessPublishedDAL=value;
			}
		}
		#endregion
			#region 76 数据接口
		IBPM_Define_SchemeDAL iBPM_Define_SchemeDAL;
		public IBPM_Define_SchemeDAL IBPM_Define_SchemeDAL
		{
			get
			{
				if(iBPM_Define_SchemeDAL==null)
					iBPM_Define_SchemeDAL=new BPM_Define_SchemeDAL();
				return iBPM_Define_SchemeDAL;
			}
			set
			{
				iBPM_Define_SchemeDAL=value;
			}
		}
		#endregion
			#region 77 数据接口
		IBPM_Run_InstanceDAL iBPM_Run_InstanceDAL;
		public IBPM_Run_InstanceDAL IBPM_Run_InstanceDAL
		{
			get
			{
				if(iBPM_Run_InstanceDAL==null)
					iBPM_Run_InstanceDAL=new BPM_Run_InstanceDAL();
				return iBPM_Run_InstanceDAL;
			}
			set
			{
				iBPM_Run_InstanceDAL=value;
			}
		}
		#endregion
			#region 78 数据接口
		IBPM_Run_ProcessLogDAL iBPM_Run_ProcessLogDAL;
		public IBPM_Run_ProcessLogDAL IBPM_Run_ProcessLogDAL
		{
			get
			{
				if(iBPM_Run_ProcessLogDAL==null)
					iBPM_Run_ProcessLogDAL=new BPM_Run_ProcessLogDAL();
				return iBPM_Run_ProcessLogDAL;
			}
			set
			{
				iBPM_Run_ProcessLogDAL=value;
			}
		}
		#endregion
			#region 79 数据接口
		IBPM_Run_SchemeJobDAL iBPM_Run_SchemeJobDAL;
		public IBPM_Run_SchemeJobDAL IBPM_Run_SchemeJobDAL
		{
			get
			{
				if(iBPM_Run_SchemeJobDAL==null)
					iBPM_Run_SchemeJobDAL=new BPM_Run_SchemeJobDAL();
				return iBPM_Run_SchemeJobDAL;
			}
			set
			{
				iBPM_Run_SchemeJobDAL=value;
			}
		}
		#endregion
			#region 80 数据接口
		IBPM_Run_SharedTaskDAL iBPM_Run_SharedTaskDAL;
		public IBPM_Run_SharedTaskDAL IBPM_Run_SharedTaskDAL
		{
			get
			{
				if(iBPM_Run_SharedTaskDAL==null)
					iBPM_Run_SharedTaskDAL=new BPM_Run_SharedTaskDAL();
				return iBPM_Run_SharedTaskDAL;
			}
			set
			{
				iBPM_Run_SharedTaskDAL=value;
			}
		}
		#endregion
			#region 81 数据接口
		IBPM_Run_TrackingDAL iBPM_Run_TrackingDAL;
		public IBPM_Run_TrackingDAL IBPM_Run_TrackingDAL
		{
			get
			{
				if(iBPM_Run_TrackingDAL==null)
					iBPM_Run_TrackingDAL=new BPM_Run_TrackingDAL();
				return iBPM_Run_TrackingDAL;
			}
			set
			{
				iBPM_Run_TrackingDAL=value;
			}
		}
		#endregion
			#region 82 数据接口
		IBPM_Run_UrgedDAL iBPM_Run_UrgedDAL;
		public IBPM_Run_UrgedDAL IBPM_Run_UrgedDAL
		{
			get
			{
				if(iBPM_Run_UrgedDAL==null)
					iBPM_Run_UrgedDAL=new BPM_Run_UrgedDAL();
				return iBPM_Run_UrgedDAL;
			}
			set
			{
				iBPM_Run_UrgedDAL=value;
			}
		}
		#endregion
			#region 83 数据接口
		IBPM_Run_VariableDAL iBPM_Run_VariableDAL;
		public IBPM_Run_VariableDAL IBPM_Run_VariableDAL
		{
			get
			{
				if(iBPM_Run_VariableDAL==null)
					iBPM_Run_VariableDAL=new BPM_Run_VariableDAL();
				return iBPM_Run_VariableDAL;
			}
			set
			{
				iBPM_Run_VariableDAL=value;
			}
		}
		#endregion
			#region 84 数据接口
		IBPM_Run_WorkTaskDAL iBPM_Run_WorkTaskDAL;
		public IBPM_Run_WorkTaskDAL IBPM_Run_WorkTaskDAL
		{
			get
			{
				if(iBPM_Run_WorkTaskDAL==null)
					iBPM_Run_WorkTaskDAL=new BPM_Run_WorkTaskDAL();
				return iBPM_Run_WorkTaskDAL;
			}
			set
			{
				iBPM_Run_WorkTaskDAL=value;
			}
		}
		#endregion
			#region 85 数据接口
		IBPM_Run_WorkTaskOpinionDAL iBPM_Run_WorkTaskOpinionDAL;
		public IBPM_Run_WorkTaskOpinionDAL IBPM_Run_WorkTaskOpinionDAL
		{
			get
			{
				if(iBPM_Run_WorkTaskOpinionDAL==null)
					iBPM_Run_WorkTaskOpinionDAL=new BPM_Run_WorkTaskOpinionDAL();
				return iBPM_Run_WorkTaskOpinionDAL;
			}
			set
			{
				iBPM_Run_WorkTaskOpinionDAL=value;
			}
		}
		#endregion
			#region 86 数据接口
		IBPM_UserExtInfoDAL iBPM_UserExtInfoDAL;
		public IBPM_UserExtInfoDAL IBPM_UserExtInfoDAL
		{
			get
			{
				if(iBPM_UserExtInfoDAL==null)
					iBPM_UserExtInfoDAL=new BPM_UserExtInfoDAL();
				return iBPM_UserExtInfoDAL;
			}
			set
			{
				iBPM_UserExtInfoDAL=value;
			}
		}
		#endregion
			#region 87 数据接口
		IBPM_UsuallyOpinionDAL iBPM_UsuallyOpinionDAL;
		public IBPM_UsuallyOpinionDAL IBPM_UsuallyOpinionDAL
		{
			get
			{
				if(iBPM_UsuallyOpinionDAL==null)
					iBPM_UsuallyOpinionDAL=new BPM_UsuallyOpinionDAL();
				return iBPM_UsuallyOpinionDAL;
			}
			set
			{
				iBPM_UsuallyOpinionDAL=value;
			}
		}
		#endregion
			#region 88 数据接口
		ICache_BlobInfoDAL iCache_BlobInfoDAL;
		public ICache_BlobInfoDAL ICache_BlobInfoDAL
		{
			get
			{
				if(iCache_BlobInfoDAL==null)
					iCache_BlobInfoDAL=new Cache_BlobInfoDAL();
				return iCache_BlobInfoDAL;
			}
			set
			{
				iCache_BlobInfoDAL=value;
			}
		}
		#endregion
			#region 89 数据接口
		ICache_StatDataDAL iCache_StatDataDAL;
		public ICache_StatDataDAL ICache_StatDataDAL
		{
			get
			{
				if(iCache_StatDataDAL==null)
					iCache_StatDataDAL=new Cache_StatDataDAL();
				return iCache_StatDataDAL;
			}
			set
			{
				iCache_StatDataDAL=value;
			}
		}
		#endregion
			#region 90 数据接口
		ICom_CatalogDAL iCom_CatalogDAL;
		public ICom_CatalogDAL ICom_CatalogDAL
		{
			get
			{
				if(iCom_CatalogDAL==null)
					iCom_CatalogDAL=new Com_CatalogDAL();
				return iCom_CatalogDAL;
			}
			set
			{
				iCom_CatalogDAL=value;
			}
		}
		#endregion
			#region 91 数据接口
		ICom_FormulaDAL iCom_FormulaDAL;
		public ICom_FormulaDAL ICom_FormulaDAL
		{
			get
			{
				if(iCom_FormulaDAL==null)
					iCom_FormulaDAL=new Com_FormulaDAL();
				return iCom_FormulaDAL;
			}
			set
			{
				iCom_FormulaDAL=value;
			}
		}
		#endregion
			#region 92 数据接口
		ICom_JetTableItemsDAL iCom_JetTableItemsDAL;
		public ICom_JetTableItemsDAL ICom_JetTableItemsDAL
		{
			get
			{
				if(iCom_JetTableItemsDAL==null)
					iCom_JetTableItemsDAL=new Com_JetTableItemsDAL();
				return iCom_JetTableItemsDAL;
			}
			set
			{
				iCom_JetTableItemsDAL=value;
			}
		}
		#endregion
			#region 93 数据接口
		ICom_JetTableMainDAL iCom_JetTableMainDAL;
		public ICom_JetTableMainDAL ICom_JetTableMainDAL
		{
			get
			{
				if(iCom_JetTableMainDAL==null)
					iCom_JetTableMainDAL=new Com_JetTableMainDAL();
				return iCom_JetTableMainDAL;
			}
			set
			{
				iCom_JetTableMainDAL=value;
			}
		}
		#endregion
			#region 94 数据接口
		ICom_LimitItemsDAL iCom_LimitItemsDAL;
		public ICom_LimitItemsDAL ICom_LimitItemsDAL
		{
			get
			{
				if(iCom_LimitItemsDAL==null)
					iCom_LimitItemsDAL=new Com_LimitItemsDAL();
				return iCom_LimitItemsDAL;
			}
			set
			{
				iCom_LimitItemsDAL=value;
			}
		}
		#endregion
			#region 95 数据接口
		ICom_LimitMainDAL iCom_LimitMainDAL;
		public ICom_LimitMainDAL ICom_LimitMainDAL
		{
			get
			{
				if(iCom_LimitMainDAL==null)
					iCom_LimitMainDAL=new Com_LimitMainDAL();
				return iCom_LimitMainDAL;
			}
			set
			{
				iCom_LimitMainDAL=value;
			}
		}
		#endregion
			#region 96 数据接口
		ICom_MusterSimpleDAL iCom_MusterSimpleDAL;
		public ICom_MusterSimpleDAL ICom_MusterSimpleDAL
		{
			get
			{
				if(iCom_MusterSimpleDAL==null)
					iCom_MusterSimpleDAL=new Com_MusterSimpleDAL();
				return iCom_MusterSimpleDAL;
			}
			set
			{
				iCom_MusterSimpleDAL=value;
			}
		}
		#endregion
			#region 97 数据接口
		ICom_MusterSimpleFieldsDAL iCom_MusterSimpleFieldsDAL;
		public ICom_MusterSimpleFieldsDAL ICom_MusterSimpleFieldsDAL
		{
			get
			{
				if(iCom_MusterSimpleFieldsDAL==null)
					iCom_MusterSimpleFieldsDAL=new Com_MusterSimpleFieldsDAL();
				return iCom_MusterSimpleFieldsDAL;
			}
			set
			{
				iCom_MusterSimpleFieldsDAL=value;
			}
		}
		#endregion
			#region 98 数据接口
		ICom_RelationBodyDAL iCom_RelationBodyDAL;
		public ICom_RelationBodyDAL ICom_RelationBodyDAL
		{
			get
			{
				if(iCom_RelationBodyDAL==null)
					iCom_RelationBodyDAL=new Com_RelationBodyDAL();
				return iCom_RelationBodyDAL;
			}
			set
			{
				iCom_RelationBodyDAL=value;
			}
		}
		#endregion
			#region 99 数据接口
		ICom_RelationMainDAL iCom_RelationMainDAL;
		public ICom_RelationMainDAL ICom_RelationMainDAL
		{
			get
			{
				if(iCom_RelationMainDAL==null)
					iCom_RelationMainDAL=new Com_RelationMainDAL();
				return iCom_RelationMainDAL;
			}
			set
			{
				iCom_RelationMainDAL=value;
			}
		}
		#endregion
			#region 100 数据接口
		ICom_SortItemsDAL iCom_SortItemsDAL;
		public ICom_SortItemsDAL ICom_SortItemsDAL
		{
			get
			{
				if(iCom_SortItemsDAL==null)
					iCom_SortItemsDAL=new Com_SortItemsDAL();
				return iCom_SortItemsDAL;
			}
			set
			{
				iCom_SortItemsDAL=value;
			}
		}
		#endregion
			#region 101 数据接口
		ICom_SortMainDAL iCom_SortMainDAL;
		public ICom_SortMainDAL ICom_SortMainDAL
		{
			get
			{
				if(iCom_SortMainDAL==null)
					iCom_SortMainDAL=new Com_SortMainDAL();
				return iCom_SortMainDAL;
			}
			set
			{
				iCom_SortMainDAL=value;
			}
		}
		#endregion
			#region 102 数据接口
		ICom_StatAnalysisItemsDAL iCom_StatAnalysisItemsDAL;
		public ICom_StatAnalysisItemsDAL ICom_StatAnalysisItemsDAL
		{
			get
			{
				if(iCom_StatAnalysisItemsDAL==null)
					iCom_StatAnalysisItemsDAL=new Com_StatAnalysisItemsDAL();
				return iCom_StatAnalysisItemsDAL;
			}
			set
			{
				iCom_StatAnalysisItemsDAL=value;
			}
		}
		#endregion
			#region 103 数据接口
		ICom_StatAnalysisMainDAL iCom_StatAnalysisMainDAL;
		public ICom_StatAnalysisMainDAL ICom_StatAnalysisMainDAL
		{
			get
			{
				if(iCom_StatAnalysisMainDAL==null)
					iCom_StatAnalysisMainDAL=new Com_StatAnalysisMainDAL();
				return iCom_StatAnalysisMainDAL;
			}
			set
			{
				iCom_StatAnalysisMainDAL=value;
			}
		}
		#endregion
			#region 104 数据接口
		ICom_StatLimitColumnsDAL iCom_StatLimitColumnsDAL;
		public ICom_StatLimitColumnsDAL ICom_StatLimitColumnsDAL
		{
			get
			{
				if(iCom_StatLimitColumnsDAL==null)
					iCom_StatLimitColumnsDAL=new Com_StatLimitColumnsDAL();
				return iCom_StatLimitColumnsDAL;
			}
			set
			{
				iCom_StatLimitColumnsDAL=value;
			}
		}
		#endregion
			#region 105 数据接口
		ICom_StatLimitMainDAL iCom_StatLimitMainDAL;
		public ICom_StatLimitMainDAL ICom_StatLimitMainDAL
		{
			get
			{
				if(iCom_StatLimitMainDAL==null)
					iCom_StatLimitMainDAL=new Com_StatLimitMainDAL();
				return iCom_StatLimitMainDAL;
			}
			set
			{
				iCom_StatLimitMainDAL=value;
			}
		}
		#endregion
			#region 106 数据接口
		ICom_StatLimitRowsDAL iCom_StatLimitRowsDAL;
		public ICom_StatLimitRowsDAL ICom_StatLimitRowsDAL
		{
			get
			{
				if(iCom_StatLimitRowsDAL==null)
					iCom_StatLimitRowsDAL=new Com_StatLimitRowsDAL();
				return iCom_StatLimitRowsDAL;
			}
			set
			{
				iCom_StatLimitRowsDAL=value;
			}
		}
		#endregion
			#region 107 数据接口
		IG01DAL iG01DAL;
		public IG01DAL IG01DAL
		{
			get
			{
				if(iG01DAL==null)
					iG01DAL=new G01DAL();
				return iG01DAL;
			}
			set
			{
				iG01DAL=value;
			}
		}
		#endregion
			#region 108 数据接口
		IHR_MusterFieldsDAL iHR_MusterFieldsDAL;
		public IHR_MusterFieldsDAL IHR_MusterFieldsDAL
		{
			get
			{
				if(iHR_MusterFieldsDAL==null)
					iHR_MusterFieldsDAL=new HR_MusterFieldsDAL();
				return iHR_MusterFieldsDAL;
			}
			set
			{
				iHR_MusterFieldsDAL=value;
			}
		}
		#endregion
			#region 109 数据接口
		IHR_MusterMainDAL iHR_MusterMainDAL;
		public IHR_MusterMainDAL IHR_MusterMainDAL
		{
			get
			{
				if(iHR_MusterMainDAL==null)
					iHR_MusterMainDAL=new HR_MusterMainDAL();
				return iHR_MusterMainDAL;
			}
			set
			{
				iHR_MusterMainDAL=value;
			}
		}
		#endregion
			#region 110 数据接口
		IOP_ExcelForm_ArgsDAL iOP_ExcelForm_ArgsDAL;
		public IOP_ExcelForm_ArgsDAL IOP_ExcelForm_ArgsDAL
		{
			get
			{
				if(iOP_ExcelForm_ArgsDAL==null)
					iOP_ExcelForm_ArgsDAL=new OP_ExcelForm_ArgsDAL();
				return iOP_ExcelForm_ArgsDAL;
			}
			set
			{
				iOP_ExcelForm_ArgsDAL=value;
			}
		}
		#endregion
			#region 111 数据接口
		IOP_ExcelForm_CatalogDAL iOP_ExcelForm_CatalogDAL;
		public IOP_ExcelForm_CatalogDAL IOP_ExcelForm_CatalogDAL
		{
			get
			{
				if(iOP_ExcelForm_CatalogDAL==null)
					iOP_ExcelForm_CatalogDAL=new OP_ExcelForm_CatalogDAL();
				return iOP_ExcelForm_CatalogDAL;
			}
			set
			{
				iOP_ExcelForm_CatalogDAL=value;
			}
		}
		#endregion
			#region 112 数据接口
		IOP_ExcelForm_CellDAL iOP_ExcelForm_CellDAL;
		public IOP_ExcelForm_CellDAL IOP_ExcelForm_CellDAL
		{
			get
			{
				if(iOP_ExcelForm_CellDAL==null)
					iOP_ExcelForm_CellDAL=new OP_ExcelForm_CellDAL();
				return iOP_ExcelForm_CellDAL;
			}
			set
			{
				iOP_ExcelForm_CellDAL=value;
			}
		}
		#endregion
			#region 113 数据接口
		IOP_ExcelForm_ColDAL iOP_ExcelForm_ColDAL;
		public IOP_ExcelForm_ColDAL IOP_ExcelForm_ColDAL
		{
			get
			{
				if(iOP_ExcelForm_ColDAL==null)
					iOP_ExcelForm_ColDAL=new OP_ExcelForm_ColDAL();
				return iOP_ExcelForm_ColDAL;
			}
			set
			{
				iOP_ExcelForm_ColDAL=value;
			}
		}
		#endregion
			#region 114 数据接口
		IOP_ExcelForm_DataSourceDAL iOP_ExcelForm_DataSourceDAL;
		public IOP_ExcelForm_DataSourceDAL IOP_ExcelForm_DataSourceDAL
		{
			get
			{
				if(iOP_ExcelForm_DataSourceDAL==null)
					iOP_ExcelForm_DataSourceDAL=new OP_ExcelForm_DataSourceDAL();
				return iOP_ExcelForm_DataSourceDAL;
			}
			set
			{
				iOP_ExcelForm_DataSourceDAL=value;
			}
		}
		#endregion
			#region 115 数据接口
		IOP_ExcelForm_DataSourceParseDAL iOP_ExcelForm_DataSourceParseDAL;
		public IOP_ExcelForm_DataSourceParseDAL IOP_ExcelForm_DataSourceParseDAL
		{
			get
			{
				if(iOP_ExcelForm_DataSourceParseDAL==null)
					iOP_ExcelForm_DataSourceParseDAL=new OP_ExcelForm_DataSourceParseDAL();
				return iOP_ExcelForm_DataSourceParseDAL;
			}
			set
			{
				iOP_ExcelForm_DataSourceParseDAL=value;
			}
		}
		#endregion
			#region 116 数据接口
		IOP_ExcelForm_InputDAL iOP_ExcelForm_InputDAL;
		public IOP_ExcelForm_InputDAL IOP_ExcelForm_InputDAL
		{
			get
			{
				if(iOP_ExcelForm_InputDAL==null)
					iOP_ExcelForm_InputDAL=new OP_ExcelForm_InputDAL();
				return iOP_ExcelForm_InputDAL;
			}
			set
			{
				iOP_ExcelForm_InputDAL=value;
			}
		}
		#endregion
			#region 117 数据接口
		IOP_ExcelForm_InputTableDAL iOP_ExcelForm_InputTableDAL;
		public IOP_ExcelForm_InputTableDAL IOP_ExcelForm_InputTableDAL
		{
			get
			{
				if(iOP_ExcelForm_InputTableDAL==null)
					iOP_ExcelForm_InputTableDAL=new OP_ExcelForm_InputTableDAL();
				return iOP_ExcelForm_InputTableDAL;
			}
			set
			{
				iOP_ExcelForm_InputTableDAL=value;
			}
		}
		#endregion
			#region 118 数据接口
		IOP_ExcelForm_InputTableFieldDAL iOP_ExcelForm_InputTableFieldDAL;
		public IOP_ExcelForm_InputTableFieldDAL IOP_ExcelForm_InputTableFieldDAL
		{
			get
			{
				if(iOP_ExcelForm_InputTableFieldDAL==null)
					iOP_ExcelForm_InputTableFieldDAL=new OP_ExcelForm_InputTableFieldDAL();
				return iOP_ExcelForm_InputTableFieldDAL;
			}
			set
			{
				iOP_ExcelForm_InputTableFieldDAL=value;
			}
		}
		#endregion
			#region 119 数据接口
		IOP_ExcelForm_MainDAL iOP_ExcelForm_MainDAL;
		public IOP_ExcelForm_MainDAL IOP_ExcelForm_MainDAL
		{
			get
			{
				if(iOP_ExcelForm_MainDAL==null)
					iOP_ExcelForm_MainDAL=new OP_ExcelForm_MainDAL();
				return iOP_ExcelForm_MainDAL;
			}
			set
			{
				iOP_ExcelForm_MainDAL=value;
			}
		}
		#endregion
			#region 120 数据接口
		IOP_ExcelForm_PrivilegeDAL iOP_ExcelForm_PrivilegeDAL;
		public IOP_ExcelForm_PrivilegeDAL IOP_ExcelForm_PrivilegeDAL
		{
			get
			{
				if(iOP_ExcelForm_PrivilegeDAL==null)
					iOP_ExcelForm_PrivilegeDAL=new OP_ExcelForm_PrivilegeDAL();
				return iOP_ExcelForm_PrivilegeDAL;
			}
			set
			{
				iOP_ExcelForm_PrivilegeDAL=value;
			}
		}
		#endregion
			#region 121 数据接口
		IOP_ExcelForm_RowDAL iOP_ExcelForm_RowDAL;
		public IOP_ExcelForm_RowDAL IOP_ExcelForm_RowDAL
		{
			get
			{
				if(iOP_ExcelForm_RowDAL==null)
					iOP_ExcelForm_RowDAL=new OP_ExcelForm_RowDAL();
				return iOP_ExcelForm_RowDAL;
			}
			set
			{
				iOP_ExcelForm_RowDAL=value;
			}
		}
		#endregion
			#region 122 数据接口
		IOP_ExcelForm_RowColDAL iOP_ExcelForm_RowColDAL;
		public IOP_ExcelForm_RowColDAL IOP_ExcelForm_RowColDAL
		{
			get
			{
				if(iOP_ExcelForm_RowColDAL==null)
					iOP_ExcelForm_RowColDAL=new OP_ExcelForm_RowColDAL();
				return iOP_ExcelForm_RowColDAL;
			}
			set
			{
				iOP_ExcelForm_RowColDAL=value;
			}
		}
		#endregion
			#region 123 数据接口
		IProject_LogApiDAL iProject_LogApiDAL;
		public IProject_LogApiDAL IProject_LogApiDAL
		{
			get
			{
				if(iProject_LogApiDAL==null)
					iProject_LogApiDAL=new Project_LogApiDAL();
				return iProject_LogApiDAL;
			}
			set
			{
				iProject_LogApiDAL=value;
			}
		}
		#endregion
			#region 124 数据接口
		IRC_DataHintDAL iRC_DataHintDAL;
		public IRC_DataHintDAL IRC_DataHintDAL
		{
			get
			{
				if(iRC_DataHintDAL==null)
					iRC_DataHintDAL=new RC_DataHintDAL();
				return iRC_DataHintDAL;
			}
			set
			{
				iRC_DataHintDAL=value;
			}
		}
		#endregion
			#region 125 数据接口
		IRC_DataHintStateDAL iRC_DataHintStateDAL;
		public IRC_DataHintStateDAL IRC_DataHintStateDAL
		{
			get
			{
				if(iRC_DataHintStateDAL==null)
					iRC_DataHintStateDAL=new RC_DataHintStateDAL();
				return iRC_DataHintStateDAL;
			}
			set
			{
				iRC_DataHintStateDAL=value;
			}
		}
		#endregion
			#region 126 数据接口
		IRC_DataLimitDAL iRC_DataLimitDAL;
		public IRC_DataLimitDAL IRC_DataLimitDAL
		{
			get
			{
				if(iRC_DataLimitDAL==null)
					iRC_DataLimitDAL=new RC_DataLimitDAL();
				return iRC_DataLimitDAL;
			}
			set
			{
				iRC_DataLimitDAL=value;
			}
		}
		#endregion
			#region 127 数据接口
		IRC_ImportClientDataWayDAL iRC_ImportClientDataWayDAL;
		public IRC_ImportClientDataWayDAL IRC_ImportClientDataWayDAL
		{
			get
			{
				if(iRC_ImportClientDataWayDAL==null)
					iRC_ImportClientDataWayDAL=new RC_ImportClientDataWayDAL();
				return iRC_ImportClientDataWayDAL;
			}
			set
			{
				iRC_ImportClientDataWayDAL=value;
			}
		}
		#endregion
			#region 128 数据接口
		IRC_InfoScriptDAL iRC_InfoScriptDAL;
		public IRC_InfoScriptDAL IRC_InfoScriptDAL
		{
			get
			{
				if(iRC_InfoScriptDAL==null)
					iRC_InfoScriptDAL=new RC_InfoScriptDAL();
				return iRC_InfoScriptDAL;
			}
			set
			{
				iRC_InfoScriptDAL=value;
			}
		}
		#endregion
			#region 129 数据接口
		IRC_InfoScriptOrderDAL iRC_InfoScriptOrderDAL;
		public IRC_InfoScriptOrderDAL IRC_InfoScriptOrderDAL
		{
			get
			{
				if(iRC_InfoScriptOrderDAL==null)
					iRC_InfoScriptOrderDAL=new RC_InfoScriptOrderDAL();
				return iRC_InfoScriptOrderDAL;
			}
			set
			{
				iRC_InfoScriptOrderDAL=value;
			}
		}
		#endregion
			#region 130 数据接口
		IRC_JTMainDAL iRC_JTMainDAL;
		public IRC_JTMainDAL IRC_JTMainDAL
		{
			get
			{
				if(iRC_JTMainDAL==null)
					iRC_JTMainDAL=new RC_JTMainDAL();
				return iRC_JTMainDAL;
			}
			set
			{
				iRC_JTMainDAL=value;
			}
		}
		#endregion
			#region 131 数据接口
		IRC_MusterMainDAL iRC_MusterMainDAL;
		public IRC_MusterMainDAL IRC_MusterMainDAL
		{
			get
			{
				if(iRC_MusterMainDAL==null)
					iRC_MusterMainDAL=new RC_MusterMainDAL();
				return iRC_MusterMainDAL;
			}
			set
			{
				iRC_MusterMainDAL=value;
			}
		}
		#endregion
			#region 132 数据接口
		IRC_PolicyAttachDAL iRC_PolicyAttachDAL;
		public IRC_PolicyAttachDAL IRC_PolicyAttachDAL
		{
			get
			{
				if(iRC_PolicyAttachDAL==null)
					iRC_PolicyAttachDAL=new RC_PolicyAttachDAL();
				return iRC_PolicyAttachDAL;
			}
			set
			{
				iRC_PolicyAttachDAL=value;
			}
		}
		#endregion
			#region 133 数据接口
		IRC_PolicyDetailDAL iRC_PolicyDetailDAL;
		public IRC_PolicyDetailDAL IRC_PolicyDetailDAL
		{
			get
			{
				if(iRC_PolicyDetailDAL==null)
					iRC_PolicyDetailDAL=new RC_PolicyDetailDAL();
				return iRC_PolicyDetailDAL;
			}
			set
			{
				iRC_PolicyDetailDAL=value;
			}
		}
		#endregion
			#region 134 数据接口
		IRC_PolicyGroupDAL iRC_PolicyGroupDAL;
		public IRC_PolicyGroupDAL IRC_PolicyGroupDAL
		{
			get
			{
				if(iRC_PolicyGroupDAL==null)
					iRC_PolicyGroupDAL=new RC_PolicyGroupDAL();
				return iRC_PolicyGroupDAL;
			}
			set
			{
				iRC_PolicyGroupDAL=value;
			}
		}
		#endregion
			#region 135 数据接口
		IRC_SearchContainerResultDAL iRC_SearchContainerResultDAL;
		public IRC_SearchContainerResultDAL IRC_SearchContainerResultDAL
		{
			get
			{
				if(iRC_SearchContainerResultDAL==null)
					iRC_SearchContainerResultDAL=new RC_SearchContainerResultDAL();
				return iRC_SearchContainerResultDAL;
			}
			set
			{
				iRC_SearchContainerResultDAL=value;
			}
		}
		#endregion
			#region 136 数据接口
		IRC_StatMainDAL iRC_StatMainDAL;
		public IRC_StatMainDAL IRC_StatMainDAL
		{
			get
			{
				if(iRC_StatMainDAL==null)
					iRC_StatMainDAL=new RC_StatMainDAL();
				return iRC_StatMainDAL;
			}
			set
			{
				iRC_StatMainDAL=value;
			}
		}
		#endregion
			#region 137 数据接口
		IRC_StatMusterFieldDAL iRC_StatMusterFieldDAL;
		public IRC_StatMusterFieldDAL IRC_StatMusterFieldDAL
		{
			get
			{
				if(iRC_StatMusterFieldDAL==null)
					iRC_StatMusterFieldDAL=new RC_StatMusterFieldDAL();
				return iRC_StatMusterFieldDAL;
			}
			set
			{
				iRC_StatMusterFieldDAL=value;
			}
		}
		#endregion
			#region 138 数据接口
		ISM_CodeItemsDAL iSM_CodeItemsDAL;
		public ISM_CodeItemsDAL ISM_CodeItemsDAL
		{
			get
			{
				if(iSM_CodeItemsDAL==null)
					iSM_CodeItemsDAL=new SM_CodeItemsDAL();
				return iSM_CodeItemsDAL;
			}
			set
			{
				iSM_CodeItemsDAL=value;
			}
		}
		#endregion
			#region 139 数据接口
		ISM_CodeTableDAL iSM_CodeTableDAL;
		public ISM_CodeTableDAL ISM_CodeTableDAL
		{
			get
			{
				if(iSM_CodeTableDAL==null)
					iSM_CodeTableDAL=new SM_CodeTableDAL();
				return iSM_CodeTableDAL;
			}
			set
			{
				iSM_CodeTableDAL=value;
			}
		}
		#endregion
			#region 140 数据接口
		ISM_CodeTableGroupDAL iSM_CodeTableGroupDAL;
		public ISM_CodeTableGroupDAL ISM_CodeTableGroupDAL
		{
			get
			{
				if(iSM_CodeTableGroupDAL==null)
					iSM_CodeTableGroupDAL=new SM_CodeTableGroupDAL();
				return iSM_CodeTableGroupDAL;
			}
			set
			{
				iSM_CodeTableGroupDAL=value;
			}
		}
		#endregion
			#region 141 数据接口
		ISM_ConsoleUIGroupDAL iSM_ConsoleUIGroupDAL;
		public ISM_ConsoleUIGroupDAL ISM_ConsoleUIGroupDAL
		{
			get
			{
				if(iSM_ConsoleUIGroupDAL==null)
					iSM_ConsoleUIGroupDAL=new SM_ConsoleUIGroupDAL();
				return iSM_ConsoleUIGroupDAL;
			}
			set
			{
				iSM_ConsoleUIGroupDAL=value;
			}
		}
		#endregion
			#region 142 数据接口
		ISM_ConsoleUIItemDAL iSM_ConsoleUIItemDAL;
		public ISM_ConsoleUIItemDAL ISM_ConsoleUIItemDAL
		{
			get
			{
				if(iSM_ConsoleUIItemDAL==null)
					iSM_ConsoleUIItemDAL=new SM_ConsoleUIItemDAL();
				return iSM_ConsoleUIItemDAL;
			}
			set
			{
				iSM_ConsoleUIItemDAL=value;
			}
		}
		#endregion
			#region 143 数据接口
		ISM_ConsoleUIWayDAL iSM_ConsoleUIWayDAL;
		public ISM_ConsoleUIWayDAL ISM_ConsoleUIWayDAL
		{
			get
			{
				if(iSM_ConsoleUIWayDAL==null)
					iSM_ConsoleUIWayDAL=new SM_ConsoleUIWayDAL();
				return iSM_ConsoleUIWayDAL;
			}
			set
			{
				iSM_ConsoleUIWayDAL=value;
			}
		}
		#endregion
			#region 144 数据接口
		ISM_ConsoleUIWayRoleDAL iSM_ConsoleUIWayRoleDAL;
		public ISM_ConsoleUIWayRoleDAL ISM_ConsoleUIWayRoleDAL
		{
			get
			{
				if(iSM_ConsoleUIWayRoleDAL==null)
					iSM_ConsoleUIWayRoleDAL=new SM_ConsoleUIWayRoleDAL();
				return iSM_ConsoleUIWayRoleDAL;
			}
			set
			{
				iSM_ConsoleUIWayRoleDAL=value;
			}
		}
		#endregion
			#region 145 数据接口
		ISM_DBConnectionDAL iSM_DBConnectionDAL;
		public ISM_DBConnectionDAL ISM_DBConnectionDAL
		{
			get
			{
				if(iSM_DBConnectionDAL==null)
					iSM_DBConnectionDAL=new SM_DBConnectionDAL();
				return iSM_DBConnectionDAL;
			}
			set
			{
				iSM_DBConnectionDAL=value;
			}
		}
		#endregion
			#region 146 数据接口
		ISM_GlobalScriptDAL iSM_GlobalScriptDAL;
		public ISM_GlobalScriptDAL ISM_GlobalScriptDAL
		{
			get
			{
				if(iSM_GlobalScriptDAL==null)
					iSM_GlobalScriptDAL=new SM_GlobalScriptDAL();
				return iSM_GlobalScriptDAL;
			}
			set
			{
				iSM_GlobalScriptDAL=value;
			}
		}
		#endregion
			#region 147 数据接口
		ISM_IdentityDAL iSM_IdentityDAL;
		public ISM_IdentityDAL ISM_IdentityDAL
		{
			get
			{
				if(iSM_IdentityDAL==null)
					iSM_IdentityDAL=new SM_IdentityDAL();
				return iSM_IdentityDAL;
			}
			set
			{
				iSM_IdentityDAL=value;
			}
		}
		#endregion
			#region 148 数据接口
		ISM_LogDAL iSM_LogDAL;
		public ISM_LogDAL ISM_LogDAL
		{
			get
			{
				if(iSM_LogDAL==null)
					iSM_LogDAL=new SM_LogDAL();
				return iSM_LogDAL;
			}
			set
			{
				iSM_LogDAL=value;
			}
		}
		#endregion
			#region 149 数据接口
		ISM_LogCycleTimerDAL iSM_LogCycleTimerDAL;
		public ISM_LogCycleTimerDAL ISM_LogCycleTimerDAL
		{
			get
			{
				if(iSM_LogCycleTimerDAL==null)
					iSM_LogCycleTimerDAL=new SM_LogCycleTimerDAL();
				return iSM_LogCycleTimerDAL;
			}
			set
			{
				iSM_LogCycleTimerDAL=value;
			}
		}
		#endregion
			#region 150 数据接口
		ISM_LogDevelopDAL iSM_LogDevelopDAL;
		public ISM_LogDevelopDAL ISM_LogDevelopDAL
		{
			get
			{
				if(iSM_LogDevelopDAL==null)
					iSM_LogDevelopDAL=new SM_LogDevelopDAL();
				return iSM_LogDevelopDAL;
			}
			set
			{
				iSM_LogDevelopDAL=value;
			}
		}
		#endregion
			#region 151 数据接口
		ISM_LogSystemDAL iSM_LogSystemDAL;
		public ISM_LogSystemDAL ISM_LogSystemDAL
		{
			get
			{
				if(iSM_LogSystemDAL==null)
					iSM_LogSystemDAL=new SM_LogSystemDAL();
				return iSM_LogSystemDAL;
			}
			set
			{
				iSM_LogSystemDAL=value;
			}
		}
		#endregion
			#region 152 数据接口
		ISM_PersonClassDAL iSM_PersonClassDAL;
		public ISM_PersonClassDAL ISM_PersonClassDAL
		{
			get
			{
				if(iSM_PersonClassDAL==null)
					iSM_PersonClassDAL=new SM_PersonClassDAL();
				return iSM_PersonClassDAL;
			}
			set
			{
				iSM_PersonClassDAL=value;
			}
		}
		#endregion
			#region 153 数据接口
		ISM_PluginDAL iSM_PluginDAL;
		public ISM_PluginDAL ISM_PluginDAL
		{
			get
			{
				if(iSM_PluginDAL==null)
					iSM_PluginDAL=new SM_PluginDAL();
				return iSM_PluginDAL;
			}
			set
			{
				iSM_PluginDAL=value;
			}
		}
		#endregion
			#region 154 数据接口
		ISM_Prototype_SimpleDAL iSM_Prototype_SimpleDAL;
		public ISM_Prototype_SimpleDAL ISM_Prototype_SimpleDAL
		{
			get
			{
				if(iSM_Prototype_SimpleDAL==null)
					iSM_Prototype_SimpleDAL=new SM_Prototype_SimpleDAL();
				return iSM_Prototype_SimpleDAL;
			}
			set
			{
				iSM_Prototype_SimpleDAL=value;
			}
		}
		#endregion
			#region 155 数据接口
		ISM_PYDAL iSM_PYDAL;
		public ISM_PYDAL ISM_PYDAL
		{
			get
			{
				if(iSM_PYDAL==null)
					iSM_PYDAL=new SM_PYDAL();
				return iSM_PYDAL;
			}
			set
			{
				iSM_PYDAL=value;
			}
		}
		#endregion
			#region 156 数据接口
		ISM_SchedulerDAL iSM_SchedulerDAL;
		public ISM_SchedulerDAL ISM_SchedulerDAL
		{
			get
			{
				if(iSM_SchedulerDAL==null)
					iSM_SchedulerDAL=new SM_SchedulerDAL();
				return iSM_SchedulerDAL;
			}
			set
			{
				iSM_SchedulerDAL=value;
			}
		}
		#endregion
			#region 157 数据接口
		ISM_SchedulerNotifyDAL iSM_SchedulerNotifyDAL;
		public ISM_SchedulerNotifyDAL ISM_SchedulerNotifyDAL
		{
			get
			{
				if(iSM_SchedulerNotifyDAL==null)
					iSM_SchedulerNotifyDAL=new SM_SchedulerNotifyDAL();
				return iSM_SchedulerNotifyDAL;
			}
			set
			{
				iSM_SchedulerNotifyDAL=value;
			}
		}
		#endregion
			#region 158 数据接口
		ISM_SchedulerPlanDAL iSM_SchedulerPlanDAL;
		public ISM_SchedulerPlanDAL ISM_SchedulerPlanDAL
		{
			get
			{
				if(iSM_SchedulerPlanDAL==null)
					iSM_SchedulerPlanDAL=new SM_SchedulerPlanDAL();
				return iSM_SchedulerPlanDAL;
			}
			set
			{
				iSM_SchedulerPlanDAL=value;
			}
		}
		#endregion
			#region 159 数据接口
		ISM_SchedulerRunLogDAL iSM_SchedulerRunLogDAL;
		public ISM_SchedulerRunLogDAL ISM_SchedulerRunLogDAL
		{
			get
			{
				if(iSM_SchedulerRunLogDAL==null)
					iSM_SchedulerRunLogDAL=new SM_SchedulerRunLogDAL();
				return iSM_SchedulerRunLogDAL;
			}
			set
			{
				iSM_SchedulerRunLogDAL=value;
			}
		}
		#endregion
			#region 160 数据接口
		ISM_SchedulerTaskDAL iSM_SchedulerTaskDAL;
		public ISM_SchedulerTaskDAL ISM_SchedulerTaskDAL
		{
			get
			{
				if(iSM_SchedulerTaskDAL==null)
					iSM_SchedulerTaskDAL=new SM_SchedulerTaskDAL();
				return iSM_SchedulerTaskDAL;
			}
			set
			{
				iSM_SchedulerTaskDAL=value;
			}
		}
		#endregion
			#region 161 数据接口
		ISM_SequenceManageDAL iSM_SequenceManageDAL;
		public ISM_SequenceManageDAL ISM_SequenceManageDAL
		{
			get
			{
				if(iSM_SequenceManageDAL==null)
					iSM_SequenceManageDAL=new SM_SequenceManageDAL();
				return iSM_SequenceManageDAL;
			}
			set
			{
				iSM_SequenceManageDAL=value;
			}
		}
		#endregion
			#region 162 数据接口
		ISM_SetDBDAL iSM_SetDBDAL;
		public ISM_SetDBDAL ISM_SetDBDAL
		{
			get
			{
				if(iSM_SetDBDAL==null)
					iSM_SetDBDAL=new SM_SetDBDAL();
				return iSM_SetDBDAL;
			}
			set
			{
				iSM_SetDBDAL=value;
			}
		}
		#endregion
			#region 163 数据接口
		ISM_SetItemCalcDAL iSM_SetItemCalcDAL;
		public ISM_SetItemCalcDAL ISM_SetItemCalcDAL
		{
			get
			{
				if(iSM_SetItemCalcDAL==null)
					iSM_SetItemCalcDAL=new SM_SetItemCalcDAL();
				return iSM_SetItemCalcDAL;
			}
			set
			{
				iSM_SetItemCalcDAL=value;
			}
		}
		#endregion
			#region 164 数据接口
		ISM_SetItemsDAL iSM_SetItemsDAL;
		public ISM_SetItemsDAL ISM_SetItemsDAL
		{
			get
			{
				if(iSM_SetItemsDAL==null)
					iSM_SetItemsDAL=new SM_SetItemsDAL();
				return iSM_SetItemsDAL;
			}
			set
			{
				iSM_SetItemsDAL=value;
			}
		}
		#endregion
			#region 165 数据接口
		ISM_SetItemUserConfigDAL iSM_SetItemUserConfigDAL;
		public ISM_SetItemUserConfigDAL ISM_SetItemUserConfigDAL
		{
			get
			{
				if(iSM_SetItemUserConfigDAL==null)
					iSM_SetItemUserConfigDAL=new SM_SetItemUserConfigDAL();
				return iSM_SetItemUserConfigDAL;
			}
			set
			{
				iSM_SetItemUserConfigDAL=value;
			}
		}
		#endregion
			#region 166 数据接口
		ISM_SetTableDAL iSM_SetTableDAL;
		public ISM_SetTableDAL ISM_SetTableDAL
		{
			get
			{
				if(iSM_SetTableDAL==null)
					iSM_SetTableDAL=new SM_SetTableDAL();
				return iSM_SetTableDAL;
			}
			set
			{
				iSM_SetTableDAL=value;
			}
		}
		#endregion
			#region 167 数据接口
		ISM_SetTableUserConfigDAL iSM_SetTableUserConfigDAL;
		public ISM_SetTableUserConfigDAL ISM_SetTableUserConfigDAL
		{
			get
			{
				if(iSM_SetTableUserConfigDAL==null)
					iSM_SetTableUserConfigDAL=new SM_SetTableUserConfigDAL();
				return iSM_SetTableUserConfigDAL;
			}
			set
			{
				iSM_SetTableUserConfigDAL=value;
			}
		}
		#endregion
			#region 168 数据接口
		ISM_SetWayUserConfigDAL iSM_SetWayUserConfigDAL;
		public ISM_SetWayUserConfigDAL ISM_SetWayUserConfigDAL
		{
			get
			{
				if(iSM_SetWayUserConfigDAL==null)
					iSM_SetWayUserConfigDAL=new SM_SetWayUserConfigDAL();
				return iSM_SetWayUserConfigDAL;
			}
			set
			{
				iSM_SetWayUserConfigDAL=value;
			}
		}
		#endregion
			#region 169 数据接口
		ISM_SqlTemplet_ArgsDAL iSM_SqlTemplet_ArgsDAL;
		public ISM_SqlTemplet_ArgsDAL ISM_SqlTemplet_ArgsDAL
		{
			get
			{
				if(iSM_SqlTemplet_ArgsDAL==null)
					iSM_SqlTemplet_ArgsDAL=new SM_SqlTemplet_ArgsDAL();
				return iSM_SqlTemplet_ArgsDAL;
			}
			set
			{
				iSM_SqlTemplet_ArgsDAL=value;
			}
		}
		#endregion
			#region 170 数据接口
		ISM_SqlTemplet_CatalogDAL iSM_SqlTemplet_CatalogDAL;
		public ISM_SqlTemplet_CatalogDAL ISM_SqlTemplet_CatalogDAL
		{
			get
			{
				if(iSM_SqlTemplet_CatalogDAL==null)
					iSM_SqlTemplet_CatalogDAL=new SM_SqlTemplet_CatalogDAL();
				return iSM_SqlTemplet_CatalogDAL;
			}
			set
			{
				iSM_SqlTemplet_CatalogDAL=value;
			}
		}
		#endregion
			#region 171 数据接口
		ISM_SqlTemplet_MainDAL iSM_SqlTemplet_MainDAL;
		public ISM_SqlTemplet_MainDAL ISM_SqlTemplet_MainDAL
		{
			get
			{
				if(iSM_SqlTemplet_MainDAL==null)
					iSM_SqlTemplet_MainDAL=new SM_SqlTemplet_MainDAL();
				return iSM_SqlTemplet_MainDAL;
			}
			set
			{
				iSM_SqlTemplet_MainDAL=value;
			}
		}
		#endregion
			#region 172 数据接口
		ISM_Stamp_UnitDAL iSM_Stamp_UnitDAL;
		public ISM_Stamp_UnitDAL ISM_Stamp_UnitDAL
		{
			get
			{
				if(iSM_Stamp_UnitDAL==null)
					iSM_Stamp_UnitDAL=new SM_Stamp_UnitDAL();
				return iSM_Stamp_UnitDAL;
			}
			set
			{
				iSM_Stamp_UnitDAL=value;
			}
		}
		#endregion
			#region 173 数据接口
		ISM_Stamp_UnitUserDAL iSM_Stamp_UnitUserDAL;
		public ISM_Stamp_UnitUserDAL ISM_Stamp_UnitUserDAL
		{
			get
			{
				if(iSM_Stamp_UnitUserDAL==null)
					iSM_Stamp_UnitUserDAL=new SM_Stamp_UnitUserDAL();
				return iSM_Stamp_UnitUserDAL;
			}
			set
			{
				iSM_Stamp_UnitUserDAL=value;
			}
		}
		#endregion
			#region 174 数据接口
		ISM_SystemKeyValueDAL iSM_SystemKeyValueDAL;
		public ISM_SystemKeyValueDAL ISM_SystemKeyValueDAL
		{
			get
			{
				if(iSM_SystemKeyValueDAL==null)
					iSM_SystemKeyValueDAL=new SM_SystemKeyValueDAL();
				return iSM_SystemKeyValueDAL;
			}
			set
			{
				iSM_SystemKeyValueDAL=value;
			}
		}
		#endregion
			#region 175 数据接口
		ISM_SystemMessageDAL iSM_SystemMessageDAL;
		public ISM_SystemMessageDAL ISM_SystemMessageDAL
		{
			get
			{
				if(iSM_SystemMessageDAL==null)
					iSM_SystemMessageDAL=new SM_SystemMessageDAL();
				return iSM_SystemMessageDAL;
			}
			set
			{
				iSM_SystemMessageDAL=value;
			}
		}
		#endregion
			#region 176 数据接口
		ISM_SystemModuleKeyFileDAL iSM_SystemModuleKeyFileDAL;
		public ISM_SystemModuleKeyFileDAL ISM_SystemModuleKeyFileDAL
		{
			get
			{
				if(iSM_SystemModuleKeyFileDAL==null)
					iSM_SystemModuleKeyFileDAL=new SM_SystemModuleKeyFileDAL();
				return iSM_SystemModuleKeyFileDAL;
			}
			set
			{
				iSM_SystemModuleKeyFileDAL=value;
			}
		}
		#endregion
			#region 177 数据接口
		ISM_SystemModuleKeyValueDAL iSM_SystemModuleKeyValueDAL;
		public ISM_SystemModuleKeyValueDAL ISM_SystemModuleKeyValueDAL
		{
			get
			{
				if(iSM_SystemModuleKeyValueDAL==null)
					iSM_SystemModuleKeyValueDAL=new SM_SystemModuleKeyValueDAL();
				return iSM_SystemModuleKeyValueDAL;
			}
			set
			{
				iSM_SystemModuleKeyValueDAL=value;
			}
		}
		#endregion
			#region 178 数据接口
		ISM_Theme_ConfigV2DAL iSM_Theme_ConfigV2DAL;
		public ISM_Theme_ConfigV2DAL ISM_Theme_ConfigV2DAL
		{
			get
			{
				if(iSM_Theme_ConfigV2DAL==null)
					iSM_Theme_ConfigV2DAL=new SM_Theme_ConfigV2DAL();
				return iSM_Theme_ConfigV2DAL;
			}
			set
			{
				iSM_Theme_ConfigV2DAL=value;
			}
		}
		#endregion
			#region 179 数据接口
		ISM_Theme_ConfigV2_FileDAL iSM_Theme_ConfigV2_FileDAL;
		public ISM_Theme_ConfigV2_FileDAL ISM_Theme_ConfigV2_FileDAL
		{
			get
			{
				if(iSM_Theme_ConfigV2_FileDAL==null)
					iSM_Theme_ConfigV2_FileDAL=new SM_Theme_ConfigV2_FileDAL();
				return iSM_Theme_ConfigV2_FileDAL;
			}
			set
			{
				iSM_Theme_ConfigV2_FileDAL=value;
			}
		}
		#endregion
			#region 180 数据接口
		ISM_Theme_ConfigV2_RoleDAL iSM_Theme_ConfigV2_RoleDAL;
		public ISM_Theme_ConfigV2_RoleDAL ISM_Theme_ConfigV2_RoleDAL
		{
			get
			{
				if(iSM_Theme_ConfigV2_RoleDAL==null)
					iSM_Theme_ConfigV2_RoleDAL=new SM_Theme_ConfigV2_RoleDAL();
				return iSM_Theme_ConfigV2_RoleDAL;
			}
			set
			{
				iSM_Theme_ConfigV2_RoleDAL=value;
			}
		}
		#endregion
			#region 181 数据接口
		ISM_Todo_DataWarnDAL iSM_Todo_DataWarnDAL;
		public ISM_Todo_DataWarnDAL ISM_Todo_DataWarnDAL
		{
			get
			{
				if(iSM_Todo_DataWarnDAL==null)
					iSM_Todo_DataWarnDAL=new SM_Todo_DataWarnDAL();
				return iSM_Todo_DataWarnDAL;
			}
			set
			{
				iSM_Todo_DataWarnDAL=value;
			}
		}
		#endregion
			#region 182 数据接口
		ISM_Todo_NoticeDAL iSM_Todo_NoticeDAL;
		public ISM_Todo_NoticeDAL ISM_Todo_NoticeDAL
		{
			get
			{
				if(iSM_Todo_NoticeDAL==null)
					iSM_Todo_NoticeDAL=new SM_Todo_NoticeDAL();
				return iSM_Todo_NoticeDAL;
			}
			set
			{
				iSM_Todo_NoticeDAL=value;
			}
		}
		#endregion
			#region 183 数据接口
		ISM_UserKeyValueDAL iSM_UserKeyValueDAL;
		public ISM_UserKeyValueDAL ISM_UserKeyValueDAL
		{
			get
			{
				if(iSM_UserKeyValueDAL==null)
					iSM_UserKeyValueDAL=new SM_UserKeyValueDAL();
				return iSM_UserKeyValueDAL;
			}
			set
			{
				iSM_UserKeyValueDAL=value;
			}
		}
		#endregion
			#region 184 数据接口
		ISM_UserKeyValueExDAL iSM_UserKeyValueExDAL;
		public ISM_UserKeyValueExDAL ISM_UserKeyValueExDAL
		{
			get
			{
				if(iSM_UserKeyValueExDAL==null)
					iSM_UserKeyValueExDAL=new SM_UserKeyValueExDAL();
				return iSM_UserKeyValueExDAL;
			}
			set
			{
				iSM_UserKeyValueExDAL=value;
			}
		}
		#endregion
			#region 185 数据接口
		ISM_UserOnlineLoggerDAL iSM_UserOnlineLoggerDAL;
		public ISM_UserOnlineLoggerDAL ISM_UserOnlineLoggerDAL
		{
			get
			{
				if(iSM_UserOnlineLoggerDAL==null)
					iSM_UserOnlineLoggerDAL=new SM_UserOnlineLoggerDAL();
				return iSM_UserOnlineLoggerDAL;
			}
			set
			{
				iSM_UserOnlineLoggerDAL=value;
			}
		}
		#endregion
			#region 186 数据接口
		ISM_UserRelationDAL iSM_UserRelationDAL;
		public ISM_UserRelationDAL ISM_UserRelationDAL
		{
			get
			{
				if(iSM_UserRelationDAL==null)
					iSM_UserRelationDAL=new SM_UserRelationDAL();
				return iSM_UserRelationDAL;
			}
			set
			{
				iSM_UserRelationDAL=value;
			}
		}
		#endregion
			#region 187 数据接口
		ISM_UserRelationItemDAL iSM_UserRelationItemDAL;
		public ISM_UserRelationItemDAL ISM_UserRelationItemDAL
		{
			get
			{
				if(iSM_UserRelationItemDAL==null)
					iSM_UserRelationItemDAL=new SM_UserRelationItemDAL();
				return iSM_UserRelationItemDAL;
			}
			set
			{
				iSM_UserRelationItemDAL=value;
			}
		}
		#endregion
			#region 188 数据接口
		ISM_VersionDAL iSM_VersionDAL;
		public ISM_VersionDAL ISM_VersionDAL
		{
			get
			{
				if(iSM_VersionDAL==null)
					iSM_VersionDAL=new SM_VersionDAL();
				return iSM_VersionDAL;
			}
			set
			{
				iSM_VersionDAL=value;
			}
		}
		#endregion
			#region 189 数据接口
		ISM_Weixin_SystemConfigDAL iSM_Weixin_SystemConfigDAL;
		public ISM_Weixin_SystemConfigDAL ISM_Weixin_SystemConfigDAL
		{
			get
			{
				if(iSM_Weixin_SystemConfigDAL==null)
					iSM_Weixin_SystemConfigDAL=new SM_Weixin_SystemConfigDAL();
				return iSM_Weixin_SystemConfigDAL;
			}
			set
			{
				iSM_Weixin_SystemConfigDAL=value;
			}
		}
		#endregion
			#region 190 数据接口
		ISM_WidgetHomepage_MainDAL iSM_WidgetHomepage_MainDAL;
		public ISM_WidgetHomepage_MainDAL ISM_WidgetHomepage_MainDAL
		{
			get
			{
				if(iSM_WidgetHomepage_MainDAL==null)
					iSM_WidgetHomepage_MainDAL=new SM_WidgetHomepage_MainDAL();
				return iSM_WidgetHomepage_MainDAL;
			}
			set
			{
				iSM_WidgetHomepage_MainDAL=value;
			}
		}
		#endregion
			#region 191 数据接口
		ISM_WidgetHomepage_UserConfigDAL iSM_WidgetHomepage_UserConfigDAL;
		public ISM_WidgetHomepage_UserConfigDAL ISM_WidgetHomepage_UserConfigDAL
		{
			get
			{
				if(iSM_WidgetHomepage_UserConfigDAL==null)
					iSM_WidgetHomepage_UserConfigDAL=new SM_WidgetHomepage_UserConfigDAL();
				return iSM_WidgetHomepage_UserConfigDAL;
			}
			set
			{
				iSM_WidgetHomepage_UserConfigDAL=value;
			}
		}
		#endregion
			#region 192 数据接口
		ISM_WidgetModule_ArgsDAL iSM_WidgetModule_ArgsDAL;
		public ISM_WidgetModule_ArgsDAL ISM_WidgetModule_ArgsDAL
		{
			get
			{
				if(iSM_WidgetModule_ArgsDAL==null)
					iSM_WidgetModule_ArgsDAL=new SM_WidgetModule_ArgsDAL();
				return iSM_WidgetModule_ArgsDAL;
			}
			set
			{
				iSM_WidgetModule_ArgsDAL=value;
			}
		}
		#endregion
			#region 193 数据接口
		ISM_WidgetModule_CatalogDAL iSM_WidgetModule_CatalogDAL;
		public ISM_WidgetModule_CatalogDAL ISM_WidgetModule_CatalogDAL
		{
			get
			{
				if(iSM_WidgetModule_CatalogDAL==null)
					iSM_WidgetModule_CatalogDAL=new SM_WidgetModule_CatalogDAL();
				return iSM_WidgetModule_CatalogDAL;
			}
			set
			{
				iSM_WidgetModule_CatalogDAL=value;
			}
		}
		#endregion
			#region 194 数据接口
		ISM_WidgetModule_FilesDAL iSM_WidgetModule_FilesDAL;
		public ISM_WidgetModule_FilesDAL ISM_WidgetModule_FilesDAL
		{
			get
			{
				if(iSM_WidgetModule_FilesDAL==null)
					iSM_WidgetModule_FilesDAL=new SM_WidgetModule_FilesDAL();
				return iSM_WidgetModule_FilesDAL;
			}
			set
			{
				iSM_WidgetModule_FilesDAL=value;
			}
		}
		#endregion
			#region 195 数据接口
		ISM_WidgetModule_MainDAL iSM_WidgetModule_MainDAL;
		public ISM_WidgetModule_MainDAL ISM_WidgetModule_MainDAL
		{
			get
			{
				if(iSM_WidgetModule_MainDAL==null)
					iSM_WidgetModule_MainDAL=new SM_WidgetModule_MainDAL();
				return iSM_WidgetModule_MainDAL;
			}
			set
			{
				iSM_WidgetModule_MainDAL=value;
			}
		}
		#endregion
			#region 196 数据接口
		ISM_WidgetModule_ObjectConfigDAL iSM_WidgetModule_ObjectConfigDAL;
		public ISM_WidgetModule_ObjectConfigDAL ISM_WidgetModule_ObjectConfigDAL
		{
			get
			{
				if(iSM_WidgetModule_ObjectConfigDAL==null)
					iSM_WidgetModule_ObjectConfigDAL=new SM_WidgetModule_ObjectConfigDAL();
				return iSM_WidgetModule_ObjectConfigDAL;
			}
			set
			{
				iSM_WidgetModule_ObjectConfigDAL=value;
			}
		}
		#endregion
			#region 197 数据接口
		ISM_WidgetModule_ToolDAL iSM_WidgetModule_ToolDAL;
		public ISM_WidgetModule_ToolDAL ISM_WidgetModule_ToolDAL
		{
			get
			{
				if(iSM_WidgetModule_ToolDAL==null)
					iSM_WidgetModule_ToolDAL=new SM_WidgetModule_ToolDAL();
				return iSM_WidgetModule_ToolDAL;
			}
			set
			{
				iSM_WidgetModule_ToolDAL=value;
			}
		}
		#endregion
			#region 198 数据接口
		ISM_WidgetModule_ToolBarDAL iSM_WidgetModule_ToolBarDAL;
		public ISM_WidgetModule_ToolBarDAL ISM_WidgetModule_ToolBarDAL
		{
			get
			{
				if(iSM_WidgetModule_ToolBarDAL==null)
					iSM_WidgetModule_ToolBarDAL=new SM_WidgetModule_ToolBarDAL();
				return iSM_WidgetModule_ToolBarDAL;
			}
			set
			{
				iSM_WidgetModule_ToolBarDAL=value;
			}
		}
		#endregion
			#region 199 数据接口
		IsysdiagramsDAL isysdiagramsDAL;
		public IsysdiagramsDAL IsysdiagramsDAL
		{
			get
			{
				if(isysdiagramsDAL==null)
					isysdiagramsDAL=new sysdiagramsDAL();
				return isysdiagramsDAL;
			}
			set
			{
				isysdiagramsDAL=value;
			}
		}
		#endregion
			#region 200 数据接口
		IT_AreaInfoDAL iT_AreaInfoDAL;
		public IT_AreaInfoDAL IT_AreaInfoDAL
		{
			get
			{
				if(iT_AreaInfoDAL==null)
					iT_AreaInfoDAL=new T_AreaInfoDAL();
				return iT_AreaInfoDAL;
			}
			set
			{
				iT_AreaInfoDAL=value;
			}
		}
		#endregion
			#region 201 数据接口
		IT_AreaPermissRelationDAL iT_AreaPermissRelationDAL;
		public IT_AreaPermissRelationDAL IT_AreaPermissRelationDAL
		{
			get
			{
				if(iT_AreaPermissRelationDAL==null)
					iT_AreaPermissRelationDAL=new T_AreaPermissRelationDAL();
				return iT_AreaPermissRelationDAL;
			}
			set
			{
				iT_AreaPermissRelationDAL=value;
			}
		}
		#endregion
			#region 202 数据接口
		IT_AskManagerDAL iT_AskManagerDAL;
		public IT_AskManagerDAL IT_AskManagerDAL
		{
			get
			{
				if(iT_AskManagerDAL==null)
					iT_AskManagerDAL=new T_AskManagerDAL();
				return iT_AskManagerDAL;
			}
			set
			{
				iT_AskManagerDAL=value;
			}
		}
		#endregion
			#region 203 数据接口
		IT_B01PermissRelationDAL iT_B01PermissRelationDAL;
		public IT_B01PermissRelationDAL IT_B01PermissRelationDAL
		{
			get
			{
				if(iT_B01PermissRelationDAL==null)
					iT_B01PermissRelationDAL=new T_B01PermissRelationDAL();
				return iT_B01PermissRelationDAL;
			}
			set
			{
				iT_B01PermissRelationDAL=value;
			}
		}
		#endregion
			#region 204 数据接口
		IT_ComplaintsDAL iT_ComplaintsDAL;
		public IT_ComplaintsDAL IT_ComplaintsDAL
		{
			get
			{
				if(iT_ComplaintsDAL==null)
					iT_ComplaintsDAL=new T_ComplaintsDAL();
				return iT_ComplaintsDAL;
			}
			set
			{
				iT_ComplaintsDAL=value;
			}
		}
		#endregion
			#region 205 数据接口
		IT_CompProInfoDAL iT_CompProInfoDAL;
		public IT_CompProInfoDAL IT_CompProInfoDAL
		{
			get
			{
				if(iT_CompProInfoDAL==null)
					iT_CompProInfoDAL=new T_CompProInfoDAL();
				return iT_CompProInfoDAL;
			}
			set
			{
				iT_CompProInfoDAL=value;
			}
		}
		#endregion
			#region 206 数据接口
		IT_DocFolderPermissRelationDAL iT_DocFolderPermissRelationDAL;
		public IT_DocFolderPermissRelationDAL IT_DocFolderPermissRelationDAL
		{
			get
			{
				if(iT_DocFolderPermissRelationDAL==null)
					iT_DocFolderPermissRelationDAL=new T_DocFolderPermissRelationDAL();
				return iT_DocFolderPermissRelationDAL;
			}
			set
			{
				iT_DocFolderPermissRelationDAL=value;
			}
		}
		#endregion
			#region 207 数据接口
		IT_DocumentFolderDAL iT_DocumentFolderDAL;
		public IT_DocumentFolderDAL IT_DocumentFolderDAL
		{
			get
			{
				if(iT_DocumentFolderDAL==null)
					iT_DocumentFolderDAL=new T_DocumentFolderDAL();
				return iT_DocumentFolderDAL;
			}
			set
			{
				iT_DocumentFolderDAL=value;
			}
		}
		#endregion
			#region 208 数据接口
		IT_DocumentFolderRelationDAL iT_DocumentFolderRelationDAL;
		public IT_DocumentFolderRelationDAL IT_DocumentFolderRelationDAL
		{
			get
			{
				if(iT_DocumentFolderRelationDAL==null)
					iT_DocumentFolderRelationDAL=new T_DocumentFolderRelationDAL();
				return iT_DocumentFolderRelationDAL;
			}
			set
			{
				iT_DocumentFolderRelationDAL=value;
			}
		}
		#endregion
			#region 209 数据接口
		IT_DocumentInfoDAL iT_DocumentInfoDAL;
		public IT_DocumentInfoDAL IT_DocumentInfoDAL
		{
			get
			{
				if(iT_DocumentInfoDAL==null)
					iT_DocumentInfoDAL=new T_DocumentInfoDAL();
				return iT_DocumentInfoDAL;
			}
			set
			{
				iT_DocumentInfoDAL=value;
			}
		}
		#endregion
			#region 210 数据接口
		IT_DocumentSetTypeDAL iT_DocumentSetTypeDAL;
		public IT_DocumentSetTypeDAL IT_DocumentSetTypeDAL
		{
			get
			{
				if(iT_DocumentSetTypeDAL==null)
					iT_DocumentSetTypeDAL=new T_DocumentSetTypeDAL();
				return iT_DocumentSetTypeDAL;
			}
			set
			{
				iT_DocumentSetTypeDAL=value;
			}
		}
		#endregion
			#region 211 数据接口
		IT_ElementPermissRelationDAL iT_ElementPermissRelationDAL;
		public IT_ElementPermissRelationDAL IT_ElementPermissRelationDAL
		{
			get
			{
				if(iT_ElementPermissRelationDAL==null)
					iT_ElementPermissRelationDAL=new T_ElementPermissRelationDAL();
				return iT_ElementPermissRelationDAL;
			}
			set
			{
				iT_ElementPermissRelationDAL=value;
			}
		}
		#endregion
			#region 212 数据接口
		IT_EnterDetailDAL iT_EnterDetailDAL;
		public IT_EnterDetailDAL IT_EnterDetailDAL
		{
			get
			{
				if(iT_EnterDetailDAL==null)
					iT_EnterDetailDAL=new T_EnterDetailDAL();
				return iT_EnterDetailDAL;
			}
			set
			{
				iT_EnterDetailDAL=value;
			}
		}
		#endregion
			#region 213 数据接口
		IT_EquipmentDAL iT_EquipmentDAL;
		public IT_EquipmentDAL IT_EquipmentDAL
		{
			get
			{
				if(iT_EquipmentDAL==null)
					iT_EquipmentDAL=new T_EquipmentDAL();
				return iT_EquipmentDAL;
			}
			set
			{
				iT_EquipmentDAL=value;
			}
		}
		#endregion
			#region 214 数据接口
		IT_ExceptionLogDAL iT_ExceptionLogDAL;
		public IT_ExceptionLogDAL IT_ExceptionLogDAL
		{
			get
			{
				if(iT_ExceptionLogDAL==null)
					iT_ExceptionLogDAL=new T_ExceptionLogDAL();
				return iT_ExceptionLogDAL;
			}
			set
			{
				iT_ExceptionLogDAL=value;
			}
		}
		#endregion
			#region 215 数据接口
		IT_FilePermissRelationDAL iT_FilePermissRelationDAL;
		public IT_FilePermissRelationDAL IT_FilePermissRelationDAL
		{
			get
			{
				if(iT_FilePermissRelationDAL==null)
					iT_FilePermissRelationDAL=new T_FilePermissRelationDAL();
				return iT_FilePermissRelationDAL;
			}
			set
			{
				iT_FilePermissRelationDAL=value;
			}
		}
		#endregion
			#region 216 数据接口
		IT_FolderPermissRelationDAL iT_FolderPermissRelationDAL;
		public IT_FolderPermissRelationDAL IT_FolderPermissRelationDAL
		{
			get
			{
				if(iT_FolderPermissRelationDAL==null)
					iT_FolderPermissRelationDAL=new T_FolderPermissRelationDAL();
				return iT_FolderPermissRelationDAL;
			}
			set
			{
				iT_FolderPermissRelationDAL=value;
			}
		}
		#endregion
			#region 217 数据接口
		IT_FunctionDAL iT_FunctionDAL;
		public IT_FunctionDAL IT_FunctionDAL
		{
			get
			{
				if(iT_FunctionDAL==null)
					iT_FunctionDAL=new T_FunctionDAL();
				return iT_FunctionDAL;
			}
			set
			{
				iT_FunctionDAL=value;
			}
		}
		#endregion
			#region 218 数据接口
		IT_ImplementDAL iT_ImplementDAL;
		public IT_ImplementDAL IT_ImplementDAL
		{
			get
			{
				if(iT_ImplementDAL==null)
					iT_ImplementDAL=new T_ImplementDAL();
				return iT_ImplementDAL;
			}
			set
			{
				iT_ImplementDAL=value;
			}
		}
		#endregion
			#region 219 数据接口
		IT_ItemCodeDAL iT_ItemCodeDAL;
		public IT_ItemCodeDAL IT_ItemCodeDAL
		{
			get
			{
				if(iT_ItemCodeDAL==null)
					iT_ItemCodeDAL=new T_ItemCodeDAL();
				return iT_ItemCodeDAL;
			}
			set
			{
				iT_ItemCodeDAL=value;
			}
		}
		#endregion
			#region 220 数据接口
		IT_ItemCodeMenumDAL iT_ItemCodeMenumDAL;
		public IT_ItemCodeMenumDAL IT_ItemCodeMenumDAL
		{
			get
			{
				if(iT_ItemCodeMenumDAL==null)
					iT_ItemCodeMenumDAL=new T_ItemCodeMenumDAL();
				return iT_ItemCodeMenumDAL;
			}
			set
			{
				iT_ItemCodeMenumDAL=value;
			}
		}
		#endregion
			#region 221 数据接口
		IT_JobResumeRelationDAL iT_JobResumeRelationDAL;
		public IT_JobResumeRelationDAL IT_JobResumeRelationDAL
		{
			get
			{
				if(iT_JobResumeRelationDAL==null)
					iT_JobResumeRelationDAL=new T_JobResumeRelationDAL();
				return iT_JobResumeRelationDAL;
			}
			set
			{
				iT_JobResumeRelationDAL=value;
			}
		}
		#endregion
			#region 222 数据接口
		IT_LimitUserDAL iT_LimitUserDAL;
		public IT_LimitUserDAL IT_LimitUserDAL
		{
			get
			{
				if(iT_LimitUserDAL==null)
					iT_LimitUserDAL=new T_LimitUserDAL();
				return iT_LimitUserDAL;
			}
			set
			{
				iT_LimitUserDAL=value;
			}
		}
		#endregion
			#region 223 数据接口
		IT_LoginDAL iT_LoginDAL;
		public IT_LoginDAL IT_LoginDAL
		{
			get
			{
				if(iT_LoginDAL==null)
					iT_LoginDAL=new T_LoginDAL();
				return iT_LoginDAL;
			}
			set
			{
				iT_LoginDAL=value;
			}
		}
		#endregion
			#region 224 数据接口
		IT_LogSetingDAL iT_LogSetingDAL;
		public IT_LogSetingDAL IT_LogSetingDAL
		{
			get
			{
				if(iT_LogSetingDAL==null)
					iT_LogSetingDAL=new T_LogSetingDAL();
				return iT_LogSetingDAL;
			}
			set
			{
				iT_LogSetingDAL=value;
			}
		}
		#endregion
			#region 225 数据接口
		IT_LogSetingDetailDAL iT_LogSetingDetailDAL;
		public IT_LogSetingDetailDAL IT_LogSetingDetailDAL
		{
			get
			{
				if(iT_LogSetingDetailDAL==null)
					iT_LogSetingDetailDAL=new T_LogSetingDetailDAL();
				return iT_LogSetingDetailDAL;
			}
			set
			{
				iT_LogSetingDetailDAL=value;
			}
		}
		#endregion
			#region 226 数据接口
		IT_MessageNoticeDAL iT_MessageNoticeDAL;
		public IT_MessageNoticeDAL IT_MessageNoticeDAL
		{
			get
			{
				if(iT_MessageNoticeDAL==null)
					iT_MessageNoticeDAL=new T_MessageNoticeDAL();
				return iT_MessageNoticeDAL;
			}
			set
			{
				iT_MessageNoticeDAL=value;
			}
		}
		#endregion
			#region 227 数据接口
		IT_ModulePermissRelationDAL iT_ModulePermissRelationDAL;
		public IT_ModulePermissRelationDAL IT_ModulePermissRelationDAL
		{
			get
			{
				if(iT_ModulePermissRelationDAL==null)
					iT_ModulePermissRelationDAL=new T_ModulePermissRelationDAL();
				return iT_ModulePermissRelationDAL;
			}
			set
			{
				iT_ModulePermissRelationDAL=value;
			}
		}
		#endregion
			#region 228 数据接口
		IT_Org_UserDAL iT_Org_UserDAL;
		public IT_Org_UserDAL IT_Org_UserDAL
		{
			get
			{
				if(iT_Org_UserDAL==null)
					iT_Org_UserDAL=new T_Org_UserDAL();
				return iT_Org_UserDAL;
			}
			set
			{
				iT_Org_UserDAL=value;
			}
		}
		#endregion
			#region 229 数据接口
		IT_OrgFolderDAL iT_OrgFolderDAL;
		public IT_OrgFolderDAL IT_OrgFolderDAL
		{
			get
			{
				if(iT_OrgFolderDAL==null)
					iT_OrgFolderDAL=new T_OrgFolderDAL();
				return iT_OrgFolderDAL;
			}
			set
			{
				iT_OrgFolderDAL=value;
			}
		}
		#endregion
			#region 230 数据接口
		IT_OrgUserRelationDAL iT_OrgUserRelationDAL;
		public IT_OrgUserRelationDAL IT_OrgUserRelationDAL
		{
			get
			{
				if(iT_OrgUserRelationDAL==null)
					iT_OrgUserRelationDAL=new T_OrgUserRelationDAL();
				return iT_OrgUserRelationDAL;
			}
			set
			{
				iT_OrgUserRelationDAL=value;
			}
		}
		#endregion
			#region 231 数据接口
		IT_PageElementDAL iT_PageElementDAL;
		public IT_PageElementDAL IT_PageElementDAL
		{
			get
			{
				if(iT_PageElementDAL==null)
					iT_PageElementDAL=new T_PageElementDAL();
				return iT_PageElementDAL;
			}
			set
			{
				iT_PageElementDAL=value;
			}
		}
		#endregion
			#region 232 数据接口
		IT_PageFileDAL iT_PageFileDAL;
		public IT_PageFileDAL IT_PageFileDAL
		{
			get
			{
				if(iT_PageFileDAL==null)
					iT_PageFileDAL=new T_PageFileDAL();
				return iT_PageFileDAL;
			}
			set
			{
				iT_PageFileDAL=value;
			}
		}
		#endregion
			#region 233 数据接口
		IT_PageFolderDAL iT_PageFolderDAL;
		public IT_PageFolderDAL IT_PageFolderDAL
		{
			get
			{
				if(iT_PageFolderDAL==null)
					iT_PageFolderDAL=new T_PageFolderDAL();
				return iT_PageFolderDAL;
			}
			set
			{
				iT_PageFolderDAL=value;
			}
		}
		#endregion
			#region 234 数据接口
		IT_PayAccountDAL iT_PayAccountDAL;
		public IT_PayAccountDAL IT_PayAccountDAL
		{
			get
			{
				if(iT_PayAccountDAL==null)
					iT_PayAccountDAL=new T_PayAccountDAL();
				return iT_PayAccountDAL;
			}
			set
			{
				iT_PayAccountDAL=value;
			}
		}
		#endregion
			#region 235 数据接口
		IT_PerFuncRelationDAL iT_PerFuncRelationDAL;
		public IT_PerFuncRelationDAL IT_PerFuncRelationDAL
		{
			get
			{
				if(iT_PerFuncRelationDAL==null)
					iT_PerFuncRelationDAL=new T_PerFuncRelationDAL();
				return iT_PerFuncRelationDAL;
			}
			set
			{
				iT_PerFuncRelationDAL=value;
			}
		}
		#endregion
			#region 236 数据接口
		IT_PermissConfigDAL iT_PermissConfigDAL;
		public IT_PermissConfigDAL IT_PermissConfigDAL
		{
			get
			{
				if(iT_PermissConfigDAL==null)
					iT_PermissConfigDAL=new T_PermissConfigDAL();
				return iT_PermissConfigDAL;
			}
			set
			{
				iT_PermissConfigDAL=value;
			}
		}
		#endregion
			#region 237 数据接口
		IT_PermissionsDAL iT_PermissionsDAL;
		public IT_PermissionsDAL IT_PermissionsDAL
		{
			get
			{
				if(iT_PermissionsDAL==null)
					iT_PermissionsDAL=new T_PermissionsDAL();
				return iT_PermissionsDAL;
			}
			set
			{
				iT_PermissionsDAL=value;
			}
		}
		#endregion
			#region 238 数据接口
		IT_RoleDAL iT_RoleDAL;
		public IT_RoleDAL IT_RoleDAL
		{
			get
			{
				if(iT_RoleDAL==null)
					iT_RoleDAL=new T_RoleDAL();
				return iT_RoleDAL;
			}
			set
			{
				iT_RoleDAL=value;
			}
		}
		#endregion
			#region 239 数据接口
		IT_RoleGroupRelationDAL iT_RoleGroupRelationDAL;
		public IT_RoleGroupRelationDAL IT_RoleGroupRelationDAL
		{
			get
			{
				if(iT_RoleGroupRelationDAL==null)
					iT_RoleGroupRelationDAL=new T_RoleGroupRelationDAL();
				return iT_RoleGroupRelationDAL;
			}
			set
			{
				iT_RoleGroupRelationDAL=value;
			}
		}
		#endregion
			#region 240 数据接口
		IT_RolePermissRelationDAL iT_RolePermissRelationDAL;
		public IT_RolePermissRelationDAL IT_RolePermissRelationDAL
		{
			get
			{
				if(iT_RolePermissRelationDAL==null)
					iT_RolePermissRelationDAL=new T_RolePermissRelationDAL();
				return iT_RolePermissRelationDAL;
			}
			set
			{
				iT_RolePermissRelationDAL=value;
			}
		}
		#endregion
			#region 241 数据接口
		IT_SetMainPageDAL iT_SetMainPageDAL;
		public IT_SetMainPageDAL IT_SetMainPageDAL
		{
			get
			{
				if(iT_SetMainPageDAL==null)
					iT_SetMainPageDAL=new T_SetMainPageDAL();
				return iT_SetMainPageDAL;
			}
			set
			{
				iT_SetMainPageDAL=value;
			}
		}
		#endregion
			#region 242 数据接口
		IT_SynchronousDAL iT_SynchronousDAL;
		public IT_SynchronousDAL IT_SynchronousDAL
		{
			get
			{
				if(iT_SynchronousDAL==null)
					iT_SynchronousDAL=new T_SynchronousDAL();
				return iT_SynchronousDAL;
			}
			set
			{
				iT_SynchronousDAL=value;
			}
		}
		#endregion
			#region 243 数据接口
		IT_SysModuleDAL iT_SysModuleDAL;
		public IT_SysModuleDAL IT_SysModuleDAL
		{
			get
			{
				if(iT_SysModuleDAL==null)
					iT_SysModuleDAL=new T_SysModuleDAL();
				return iT_SysModuleDAL;
			}
			set
			{
				iT_SysModuleDAL=value;
			}
		}
		#endregion
			#region 244 数据接口
		IT_TableDAL iT_TableDAL;
		public IT_TableDAL IT_TableDAL
		{
			get
			{
				if(iT_TableDAL==null)
					iT_TableDAL=new T_TableDAL();
				return iT_TableDAL;
			}
			set
			{
				iT_TableDAL=value;
			}
		}
		#endregion
			#region 245 数据接口
		IT_TableFieldDAL iT_TableFieldDAL;
		public IT_TableFieldDAL IT_TableFieldDAL
		{
			get
			{
				if(iT_TableFieldDAL==null)
					iT_TableFieldDAL=new T_TableFieldDAL();
				return iT_TableFieldDAL;
			}
			set
			{
				iT_TableFieldDAL=value;
			}
		}
		#endregion
			#region 246 数据接口
		IT_TodoListDAL iT_TodoListDAL;
		public IT_TodoListDAL IT_TodoListDAL
		{
			get
			{
				if(iT_TodoListDAL==null)
					iT_TodoListDAL=new T_TodoListDAL();
				return iT_TodoListDAL;
			}
			set
			{
				iT_TodoListDAL=value;
			}
		}
		#endregion
			#region 247 数据接口
		IT_UserDAL iT_UserDAL;
		public IT_UserDAL IT_UserDAL
		{
			get
			{
				if(iT_UserDAL==null)
					iT_UserDAL=new T_UserDAL();
				return iT_UserDAL;
			}
			set
			{
				iT_UserDAL=value;
			}
		}
		#endregion
			#region 248 数据接口
		IT_UserGroupDAL iT_UserGroupDAL;
		public IT_UserGroupDAL IT_UserGroupDAL
		{
			get
			{
				if(iT_UserGroupDAL==null)
					iT_UserGroupDAL=new T_UserGroupDAL();
				return iT_UserGroupDAL;
			}
			set
			{
				iT_UserGroupDAL=value;
			}
		}
		#endregion
			#region 249 数据接口
		IT_UserGroupRelationDAL iT_UserGroupRelationDAL;
		public IT_UserGroupRelationDAL IT_UserGroupRelationDAL
		{
			get
			{
				if(iT_UserGroupRelationDAL==null)
					iT_UserGroupRelationDAL=new T_UserGroupRelationDAL();
				return iT_UserGroupRelationDAL;
			}
			set
			{
				iT_UserGroupRelationDAL=value;
			}
		}
		#endregion
			#region 250 数据接口
		IT_UserRoleRelationDAL iT_UserRoleRelationDAL;
		public IT_UserRoleRelationDAL IT_UserRoleRelationDAL
		{
			get
			{
				if(iT_UserRoleRelationDAL==null)
					iT_UserRoleRelationDAL=new T_UserRoleRelationDAL();
				return iT_UserRoleRelationDAL;
			}
			set
			{
				iT_UserRoleRelationDAL=value;
			}
		}
		#endregion
			#region 251 数据接口
		IT_UserUnitRelationDAL iT_UserUnitRelationDAL;
		public IT_UserUnitRelationDAL IT_UserUnitRelationDAL
		{
			get
			{
				if(iT_UserUnitRelationDAL==null)
					iT_UserUnitRelationDAL=new T_UserUnitRelationDAL();
				return iT_UserUnitRelationDAL;
			}
			set
			{
				iT_UserUnitRelationDAL=value;
			}
		}
		#endregion
			#region 252 数据接口
		IT_UseWorkerDAL iT_UseWorkerDAL;
		public IT_UseWorkerDAL IT_UseWorkerDAL
		{
			get
			{
				if(iT_UseWorkerDAL==null)
					iT_UseWorkerDAL=new T_UseWorkerDAL();
				return iT_UseWorkerDAL;
			}
			set
			{
				iT_UseWorkerDAL=value;
			}
		}
		#endregion
			#region 253 数据接口
		IV_Auth_Per_00001_System_BPM_StartDAL iV_Auth_Per_00001_System_BPM_StartDAL;
		public IV_Auth_Per_00001_System_BPM_StartDAL IV_Auth_Per_00001_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_00001_System_BPM_StartDAL==null)
					iV_Auth_Per_00001_System_BPM_StartDAL=new V_Auth_Per_00001_System_BPM_StartDAL();
				return iV_Auth_Per_00001_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_00001_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 254 数据接口
		IV_Auth_Per_00001_System_Operation_StartDAL iV_Auth_Per_00001_System_Operation_StartDAL;
		public IV_Auth_Per_00001_System_Operation_StartDAL IV_Auth_Per_00001_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_00001_System_Operation_StartDAL==null)
					iV_Auth_Per_00001_System_Operation_StartDAL=new V_Auth_Per_00001_System_Operation_StartDAL();
				return iV_Auth_Per_00001_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_00001_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 255 数据接口
		IV_Auth_Per_00001_System_Org_TreeDAL iV_Auth_Per_00001_System_Org_TreeDAL;
		public IV_Auth_Per_00001_System_Org_TreeDAL IV_Auth_Per_00001_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_00001_System_Org_TreeDAL==null)
					iV_Auth_Per_00001_System_Org_TreeDAL=new V_Auth_Per_00001_System_Org_TreeDAL();
				return iV_Auth_Per_00001_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_00001_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 256 数据接口
		IV_Auth_Per_00001_System_Person_ReadwriteDAL iV_Auth_Per_00001_System_Person_ReadwriteDAL;
		public IV_Auth_Per_00001_System_Person_ReadwriteDAL IV_Auth_Per_00001_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_00001_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_00001_System_Person_ReadwriteDAL=new V_Auth_Per_00001_System_Person_ReadwriteDAL();
				return iV_Auth_Per_00001_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_00001_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 257 数据接口
		IV_Auth_Per_00001_System_PersonClassDAL iV_Auth_Per_00001_System_PersonClassDAL;
		public IV_Auth_Per_00001_System_PersonClassDAL IV_Auth_Per_00001_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_00001_System_PersonClassDAL==null)
					iV_Auth_Per_00001_System_PersonClassDAL=new V_Auth_Per_00001_System_PersonClassDAL();
				return iV_Auth_Per_00001_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_00001_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 258 数据接口
		IV_Auth_Per_00002_System_BPM_StartDAL iV_Auth_Per_00002_System_BPM_StartDAL;
		public IV_Auth_Per_00002_System_BPM_StartDAL IV_Auth_Per_00002_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_00002_System_BPM_StartDAL==null)
					iV_Auth_Per_00002_System_BPM_StartDAL=new V_Auth_Per_00002_System_BPM_StartDAL();
				return iV_Auth_Per_00002_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_00002_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 259 数据接口
		IV_Auth_Per_00002_System_Operation_StartDAL iV_Auth_Per_00002_System_Operation_StartDAL;
		public IV_Auth_Per_00002_System_Operation_StartDAL IV_Auth_Per_00002_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_00002_System_Operation_StartDAL==null)
					iV_Auth_Per_00002_System_Operation_StartDAL=new V_Auth_Per_00002_System_Operation_StartDAL();
				return iV_Auth_Per_00002_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_00002_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 260 数据接口
		IV_Auth_Per_00002_System_Org_TreeDAL iV_Auth_Per_00002_System_Org_TreeDAL;
		public IV_Auth_Per_00002_System_Org_TreeDAL IV_Auth_Per_00002_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_00002_System_Org_TreeDAL==null)
					iV_Auth_Per_00002_System_Org_TreeDAL=new V_Auth_Per_00002_System_Org_TreeDAL();
				return iV_Auth_Per_00002_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_00002_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 261 数据接口
		IV_Auth_Per_00002_System_Person_ReadwriteDAL iV_Auth_Per_00002_System_Person_ReadwriteDAL;
		public IV_Auth_Per_00002_System_Person_ReadwriteDAL IV_Auth_Per_00002_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_00002_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_00002_System_Person_ReadwriteDAL=new V_Auth_Per_00002_System_Person_ReadwriteDAL();
				return iV_Auth_Per_00002_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_00002_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 262 数据接口
		IV_Auth_Per_00002_System_PersonClassDAL iV_Auth_Per_00002_System_PersonClassDAL;
		public IV_Auth_Per_00002_System_PersonClassDAL IV_Auth_Per_00002_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_00002_System_PersonClassDAL==null)
					iV_Auth_Per_00002_System_PersonClassDAL=new V_Auth_Per_00002_System_PersonClassDAL();
				return iV_Auth_Per_00002_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_00002_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 263 数据接口
		IV_Auth_Per_anonymous_System_BPM_StartDAL iV_Auth_Per_anonymous_System_BPM_StartDAL;
		public IV_Auth_Per_anonymous_System_BPM_StartDAL IV_Auth_Per_anonymous_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_BPM_StartDAL==null)
					iV_Auth_Per_anonymous_System_BPM_StartDAL=new V_Auth_Per_anonymous_System_BPM_StartDAL();
				return iV_Auth_Per_anonymous_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_anonymous_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 264 数据接口
		IV_Auth_Per_anonymous_System_Operation_StartDAL iV_Auth_Per_anonymous_System_Operation_StartDAL;
		public IV_Auth_Per_anonymous_System_Operation_StartDAL IV_Auth_Per_anonymous_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_Operation_StartDAL==null)
					iV_Auth_Per_anonymous_System_Operation_StartDAL=new V_Auth_Per_anonymous_System_Operation_StartDAL();
				return iV_Auth_Per_anonymous_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_anonymous_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 265 数据接口
		IV_Auth_Per_anonymous_System_Org_TreeDAL iV_Auth_Per_anonymous_System_Org_TreeDAL;
		public IV_Auth_Per_anonymous_System_Org_TreeDAL IV_Auth_Per_anonymous_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_Org_TreeDAL==null)
					iV_Auth_Per_anonymous_System_Org_TreeDAL=new V_Auth_Per_anonymous_System_Org_TreeDAL();
				return iV_Auth_Per_anonymous_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_anonymous_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 266 数据接口
		IV_Auth_Per_anonymous_System_Person_ReadwriteDAL iV_Auth_Per_anonymous_System_Person_ReadwriteDAL;
		public IV_Auth_Per_anonymous_System_Person_ReadwriteDAL IV_Auth_Per_anonymous_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_anonymous_System_Person_ReadwriteDAL=new V_Auth_Per_anonymous_System_Person_ReadwriteDAL();
				return iV_Auth_Per_anonymous_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_anonymous_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 267 数据接口
		IV_Auth_Per_anonymous_System_PersonClassDAL iV_Auth_Per_anonymous_System_PersonClassDAL;
		public IV_Auth_Per_anonymous_System_PersonClassDAL IV_Auth_Per_anonymous_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_anonymous_System_PersonClassDAL==null)
					iV_Auth_Per_anonymous_System_PersonClassDAL=new V_Auth_Per_anonymous_System_PersonClassDAL();
				return iV_Auth_Per_anonymous_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_anonymous_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 268 数据接口
		IV_Auth_Per_U00000B_System_BPM_StartDAL iV_Auth_Per_U00000B_System_BPM_StartDAL;
		public IV_Auth_Per_U00000B_System_BPM_StartDAL IV_Auth_Per_U00000B_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000B_System_BPM_StartDAL=new V_Auth_Per_U00000B_System_BPM_StartDAL();
				return iV_Auth_Per_U00000B_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000B_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 269 数据接口
		IV_Auth_Per_U00000B_System_Operation_StartDAL iV_Auth_Per_U00000B_System_Operation_StartDAL;
		public IV_Auth_Per_U00000B_System_Operation_StartDAL IV_Auth_Per_U00000B_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000B_System_Operation_StartDAL=new V_Auth_Per_U00000B_System_Operation_StartDAL();
				return iV_Auth_Per_U00000B_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000B_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 270 数据接口
		IV_Auth_Per_U00000B_System_Org_TreeDAL iV_Auth_Per_U00000B_System_Org_TreeDAL;
		public IV_Auth_Per_U00000B_System_Org_TreeDAL IV_Auth_Per_U00000B_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000B_System_Org_TreeDAL=new V_Auth_Per_U00000B_System_Org_TreeDAL();
				return iV_Auth_Per_U00000B_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000B_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 271 数据接口
		IV_Auth_Per_U00000B_System_Person_ReadwriteDAL iV_Auth_Per_U00000B_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000B_System_Person_ReadwriteDAL IV_Auth_Per_U00000B_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000B_System_Person_ReadwriteDAL=new V_Auth_Per_U00000B_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000B_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000B_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 272 数据接口
		IV_Auth_Per_U00000B_System_PersonClassDAL iV_Auth_Per_U00000B_System_PersonClassDAL;
		public IV_Auth_Per_U00000B_System_PersonClassDAL IV_Auth_Per_U00000B_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000B_System_PersonClassDAL==null)
					iV_Auth_Per_U00000B_System_PersonClassDAL=new V_Auth_Per_U00000B_System_PersonClassDAL();
				return iV_Auth_Per_U00000B_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000B_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 273 数据接口
		IV_Auth_Per_U00000C_System_BPM_StartDAL iV_Auth_Per_U00000C_System_BPM_StartDAL;
		public IV_Auth_Per_U00000C_System_BPM_StartDAL IV_Auth_Per_U00000C_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000C_System_BPM_StartDAL=new V_Auth_Per_U00000C_System_BPM_StartDAL();
				return iV_Auth_Per_U00000C_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000C_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 274 数据接口
		IV_Auth_Per_U00000C_System_Operation_StartDAL iV_Auth_Per_U00000C_System_Operation_StartDAL;
		public IV_Auth_Per_U00000C_System_Operation_StartDAL IV_Auth_Per_U00000C_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000C_System_Operation_StartDAL=new V_Auth_Per_U00000C_System_Operation_StartDAL();
				return iV_Auth_Per_U00000C_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000C_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 275 数据接口
		IV_Auth_Per_U00000C_System_Org_TreeDAL iV_Auth_Per_U00000C_System_Org_TreeDAL;
		public IV_Auth_Per_U00000C_System_Org_TreeDAL IV_Auth_Per_U00000C_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000C_System_Org_TreeDAL=new V_Auth_Per_U00000C_System_Org_TreeDAL();
				return iV_Auth_Per_U00000C_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000C_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 276 数据接口
		IV_Auth_Per_U00000C_System_Person_ReadwriteDAL iV_Auth_Per_U00000C_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000C_System_Person_ReadwriteDAL IV_Auth_Per_U00000C_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000C_System_Person_ReadwriteDAL=new V_Auth_Per_U00000C_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000C_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000C_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 277 数据接口
		IV_Auth_Per_U00000C_System_PersonClassDAL iV_Auth_Per_U00000C_System_PersonClassDAL;
		public IV_Auth_Per_U00000C_System_PersonClassDAL IV_Auth_Per_U00000C_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000C_System_PersonClassDAL==null)
					iV_Auth_Per_U00000C_System_PersonClassDAL=new V_Auth_Per_U00000C_System_PersonClassDAL();
				return iV_Auth_Per_U00000C_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000C_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 278 数据接口
		IV_Auth_Per_U00000D_System_BPM_StartDAL iV_Auth_Per_U00000D_System_BPM_StartDAL;
		public IV_Auth_Per_U00000D_System_BPM_StartDAL IV_Auth_Per_U00000D_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000D_System_BPM_StartDAL=new V_Auth_Per_U00000D_System_BPM_StartDAL();
				return iV_Auth_Per_U00000D_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000D_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 279 数据接口
		IV_Auth_Per_U00000D_System_Operation_StartDAL iV_Auth_Per_U00000D_System_Operation_StartDAL;
		public IV_Auth_Per_U00000D_System_Operation_StartDAL IV_Auth_Per_U00000D_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000D_System_Operation_StartDAL=new V_Auth_Per_U00000D_System_Operation_StartDAL();
				return iV_Auth_Per_U00000D_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000D_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 280 数据接口
		IV_Auth_Per_U00000D_System_Org_TreeDAL iV_Auth_Per_U00000D_System_Org_TreeDAL;
		public IV_Auth_Per_U00000D_System_Org_TreeDAL IV_Auth_Per_U00000D_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000D_System_Org_TreeDAL=new V_Auth_Per_U00000D_System_Org_TreeDAL();
				return iV_Auth_Per_U00000D_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000D_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 281 数据接口
		IV_Auth_Per_U00000D_System_Person_ReadwriteDAL iV_Auth_Per_U00000D_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000D_System_Person_ReadwriteDAL IV_Auth_Per_U00000D_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000D_System_Person_ReadwriteDAL=new V_Auth_Per_U00000D_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000D_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000D_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 282 数据接口
		IV_Auth_Per_U00000D_System_PersonClassDAL iV_Auth_Per_U00000D_System_PersonClassDAL;
		public IV_Auth_Per_U00000D_System_PersonClassDAL IV_Auth_Per_U00000D_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000D_System_PersonClassDAL==null)
					iV_Auth_Per_U00000D_System_PersonClassDAL=new V_Auth_Per_U00000D_System_PersonClassDAL();
				return iV_Auth_Per_U00000D_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000D_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 283 数据接口
		IV_Auth_Per_U00000E_System_BPM_StartDAL iV_Auth_Per_U00000E_System_BPM_StartDAL;
		public IV_Auth_Per_U00000E_System_BPM_StartDAL IV_Auth_Per_U00000E_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000E_System_BPM_StartDAL=new V_Auth_Per_U00000E_System_BPM_StartDAL();
				return iV_Auth_Per_U00000E_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000E_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 284 数据接口
		IV_Auth_Per_U00000E_System_Operation_StartDAL iV_Auth_Per_U00000E_System_Operation_StartDAL;
		public IV_Auth_Per_U00000E_System_Operation_StartDAL IV_Auth_Per_U00000E_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000E_System_Operation_StartDAL=new V_Auth_Per_U00000E_System_Operation_StartDAL();
				return iV_Auth_Per_U00000E_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000E_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 285 数据接口
		IV_Auth_Per_U00000E_System_Org_TreeDAL iV_Auth_Per_U00000E_System_Org_TreeDAL;
		public IV_Auth_Per_U00000E_System_Org_TreeDAL IV_Auth_Per_U00000E_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000E_System_Org_TreeDAL=new V_Auth_Per_U00000E_System_Org_TreeDAL();
				return iV_Auth_Per_U00000E_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000E_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 286 数据接口
		IV_Auth_Per_U00000E_System_Person_ReadwriteDAL iV_Auth_Per_U00000E_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000E_System_Person_ReadwriteDAL IV_Auth_Per_U00000E_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000E_System_Person_ReadwriteDAL=new V_Auth_Per_U00000E_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000E_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000E_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 287 数据接口
		IV_Auth_Per_U00000E_System_PersonClassDAL iV_Auth_Per_U00000E_System_PersonClassDAL;
		public IV_Auth_Per_U00000E_System_PersonClassDAL IV_Auth_Per_U00000E_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000E_System_PersonClassDAL==null)
					iV_Auth_Per_U00000E_System_PersonClassDAL=new V_Auth_Per_U00000E_System_PersonClassDAL();
				return iV_Auth_Per_U00000E_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000E_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 288 数据接口
		IV_Auth_Per_U00000F_System_BPM_StartDAL iV_Auth_Per_U00000F_System_BPM_StartDAL;
		public IV_Auth_Per_U00000F_System_BPM_StartDAL IV_Auth_Per_U00000F_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000F_System_BPM_StartDAL=new V_Auth_Per_U00000F_System_BPM_StartDAL();
				return iV_Auth_Per_U00000F_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000F_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 289 数据接口
		IV_Auth_Per_U00000F_System_Operation_StartDAL iV_Auth_Per_U00000F_System_Operation_StartDAL;
		public IV_Auth_Per_U00000F_System_Operation_StartDAL IV_Auth_Per_U00000F_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000F_System_Operation_StartDAL=new V_Auth_Per_U00000F_System_Operation_StartDAL();
				return iV_Auth_Per_U00000F_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000F_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 290 数据接口
		IV_Auth_Per_U00000F_System_Org_TreeDAL iV_Auth_Per_U00000F_System_Org_TreeDAL;
		public IV_Auth_Per_U00000F_System_Org_TreeDAL IV_Auth_Per_U00000F_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000F_System_Org_TreeDAL=new V_Auth_Per_U00000F_System_Org_TreeDAL();
				return iV_Auth_Per_U00000F_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000F_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 291 数据接口
		IV_Auth_Per_U00000F_System_Person_ReadwriteDAL iV_Auth_Per_U00000F_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000F_System_Person_ReadwriteDAL IV_Auth_Per_U00000F_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000F_System_Person_ReadwriteDAL=new V_Auth_Per_U00000F_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000F_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000F_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 292 数据接口
		IV_Auth_Per_U00000F_System_PersonClassDAL iV_Auth_Per_U00000F_System_PersonClassDAL;
		public IV_Auth_Per_U00000F_System_PersonClassDAL IV_Auth_Per_U00000F_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000F_System_PersonClassDAL==null)
					iV_Auth_Per_U00000F_System_PersonClassDAL=new V_Auth_Per_U00000F_System_PersonClassDAL();
				return iV_Auth_Per_U00000F_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000F_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 293 数据接口
		IV_Auth_Per_U00000G_System_BPM_StartDAL iV_Auth_Per_U00000G_System_BPM_StartDAL;
		public IV_Auth_Per_U00000G_System_BPM_StartDAL IV_Auth_Per_U00000G_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000G_System_BPM_StartDAL=new V_Auth_Per_U00000G_System_BPM_StartDAL();
				return iV_Auth_Per_U00000G_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000G_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 294 数据接口
		IV_Auth_Per_U00000G_System_Operation_StartDAL iV_Auth_Per_U00000G_System_Operation_StartDAL;
		public IV_Auth_Per_U00000G_System_Operation_StartDAL IV_Auth_Per_U00000G_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000G_System_Operation_StartDAL=new V_Auth_Per_U00000G_System_Operation_StartDAL();
				return iV_Auth_Per_U00000G_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000G_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 295 数据接口
		IV_Auth_Per_U00000G_System_Org_TreeDAL iV_Auth_Per_U00000G_System_Org_TreeDAL;
		public IV_Auth_Per_U00000G_System_Org_TreeDAL IV_Auth_Per_U00000G_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000G_System_Org_TreeDAL=new V_Auth_Per_U00000G_System_Org_TreeDAL();
				return iV_Auth_Per_U00000G_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000G_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 296 数据接口
		IV_Auth_Per_U00000G_System_Person_ReadwriteDAL iV_Auth_Per_U00000G_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000G_System_Person_ReadwriteDAL IV_Auth_Per_U00000G_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000G_System_Person_ReadwriteDAL=new V_Auth_Per_U00000G_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000G_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000G_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 297 数据接口
		IV_Auth_Per_U00000G_System_PersonClassDAL iV_Auth_Per_U00000G_System_PersonClassDAL;
		public IV_Auth_Per_U00000G_System_PersonClassDAL IV_Auth_Per_U00000G_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000G_System_PersonClassDAL==null)
					iV_Auth_Per_U00000G_System_PersonClassDAL=new V_Auth_Per_U00000G_System_PersonClassDAL();
				return iV_Auth_Per_U00000G_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000G_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 298 数据接口
		IV_Auth_Per_U00000I_System_BPM_StartDAL iV_Auth_Per_U00000I_System_BPM_StartDAL;
		public IV_Auth_Per_U00000I_System_BPM_StartDAL IV_Auth_Per_U00000I_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000I_System_BPM_StartDAL=new V_Auth_Per_U00000I_System_BPM_StartDAL();
				return iV_Auth_Per_U00000I_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000I_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 299 数据接口
		IV_Auth_Per_U00000I_System_Operation_StartDAL iV_Auth_Per_U00000I_System_Operation_StartDAL;
		public IV_Auth_Per_U00000I_System_Operation_StartDAL IV_Auth_Per_U00000I_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000I_System_Operation_StartDAL=new V_Auth_Per_U00000I_System_Operation_StartDAL();
				return iV_Auth_Per_U00000I_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000I_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 300 数据接口
		IV_Auth_Per_U00000I_System_Org_TreeDAL iV_Auth_Per_U00000I_System_Org_TreeDAL;
		public IV_Auth_Per_U00000I_System_Org_TreeDAL IV_Auth_Per_U00000I_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000I_System_Org_TreeDAL=new V_Auth_Per_U00000I_System_Org_TreeDAL();
				return iV_Auth_Per_U00000I_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000I_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 301 数据接口
		IV_Auth_Per_U00000I_System_Person_ReadwriteDAL iV_Auth_Per_U00000I_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000I_System_Person_ReadwriteDAL IV_Auth_Per_U00000I_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000I_System_Person_ReadwriteDAL=new V_Auth_Per_U00000I_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000I_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000I_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 302 数据接口
		IV_Auth_Per_U00000I_System_PersonClassDAL iV_Auth_Per_U00000I_System_PersonClassDAL;
		public IV_Auth_Per_U00000I_System_PersonClassDAL IV_Auth_Per_U00000I_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000I_System_PersonClassDAL==null)
					iV_Auth_Per_U00000I_System_PersonClassDAL=new V_Auth_Per_U00000I_System_PersonClassDAL();
				return iV_Auth_Per_U00000I_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000I_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 303 数据接口
		IV_Auth_Per_U00000J_System_BPM_StartDAL iV_Auth_Per_U00000J_System_BPM_StartDAL;
		public IV_Auth_Per_U00000J_System_BPM_StartDAL IV_Auth_Per_U00000J_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000J_System_BPM_StartDAL=new V_Auth_Per_U00000J_System_BPM_StartDAL();
				return iV_Auth_Per_U00000J_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000J_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 304 数据接口
		IV_Auth_Per_U00000J_System_Operation_StartDAL iV_Auth_Per_U00000J_System_Operation_StartDAL;
		public IV_Auth_Per_U00000J_System_Operation_StartDAL IV_Auth_Per_U00000J_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000J_System_Operation_StartDAL=new V_Auth_Per_U00000J_System_Operation_StartDAL();
				return iV_Auth_Per_U00000J_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000J_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 305 数据接口
		IV_Auth_Per_U00000J_System_Org_TreeDAL iV_Auth_Per_U00000J_System_Org_TreeDAL;
		public IV_Auth_Per_U00000J_System_Org_TreeDAL IV_Auth_Per_U00000J_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000J_System_Org_TreeDAL=new V_Auth_Per_U00000J_System_Org_TreeDAL();
				return iV_Auth_Per_U00000J_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000J_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 306 数据接口
		IV_Auth_Per_U00000J_System_Person_ReadwriteDAL iV_Auth_Per_U00000J_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000J_System_Person_ReadwriteDAL IV_Auth_Per_U00000J_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000J_System_Person_ReadwriteDAL=new V_Auth_Per_U00000J_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000J_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000J_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 307 数据接口
		IV_Auth_Per_U00000J_System_PersonClassDAL iV_Auth_Per_U00000J_System_PersonClassDAL;
		public IV_Auth_Per_U00000J_System_PersonClassDAL IV_Auth_Per_U00000J_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000J_System_PersonClassDAL==null)
					iV_Auth_Per_U00000J_System_PersonClassDAL=new V_Auth_Per_U00000J_System_PersonClassDAL();
				return iV_Auth_Per_U00000J_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000J_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 308 数据接口
		IV_Auth_Per_U00000K_System_BPM_StartDAL iV_Auth_Per_U00000K_System_BPM_StartDAL;
		public IV_Auth_Per_U00000K_System_BPM_StartDAL IV_Auth_Per_U00000K_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000K_System_BPM_StartDAL=new V_Auth_Per_U00000K_System_BPM_StartDAL();
				return iV_Auth_Per_U00000K_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000K_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 309 数据接口
		IV_Auth_Per_U00000K_System_Operation_StartDAL iV_Auth_Per_U00000K_System_Operation_StartDAL;
		public IV_Auth_Per_U00000K_System_Operation_StartDAL IV_Auth_Per_U00000K_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000K_System_Operation_StartDAL=new V_Auth_Per_U00000K_System_Operation_StartDAL();
				return iV_Auth_Per_U00000K_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000K_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 310 数据接口
		IV_Auth_Per_U00000K_System_Org_TreeDAL iV_Auth_Per_U00000K_System_Org_TreeDAL;
		public IV_Auth_Per_U00000K_System_Org_TreeDAL IV_Auth_Per_U00000K_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000K_System_Org_TreeDAL=new V_Auth_Per_U00000K_System_Org_TreeDAL();
				return iV_Auth_Per_U00000K_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000K_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 311 数据接口
		IV_Auth_Per_U00000K_System_Person_ReadwriteDAL iV_Auth_Per_U00000K_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000K_System_Person_ReadwriteDAL IV_Auth_Per_U00000K_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000K_System_Person_ReadwriteDAL=new V_Auth_Per_U00000K_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000K_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000K_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 312 数据接口
		IV_Auth_Per_U00000K_System_PersonClassDAL iV_Auth_Per_U00000K_System_PersonClassDAL;
		public IV_Auth_Per_U00000K_System_PersonClassDAL IV_Auth_Per_U00000K_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000K_System_PersonClassDAL==null)
					iV_Auth_Per_U00000K_System_PersonClassDAL=new V_Auth_Per_U00000K_System_PersonClassDAL();
				return iV_Auth_Per_U00000K_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000K_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 313 数据接口
		IV_Auth_Per_U00000L_System_BPM_StartDAL iV_Auth_Per_U00000L_System_BPM_StartDAL;
		public IV_Auth_Per_U00000L_System_BPM_StartDAL IV_Auth_Per_U00000L_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000L_System_BPM_StartDAL=new V_Auth_Per_U00000L_System_BPM_StartDAL();
				return iV_Auth_Per_U00000L_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000L_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 314 数据接口
		IV_Auth_Per_U00000L_System_Operation_StartDAL iV_Auth_Per_U00000L_System_Operation_StartDAL;
		public IV_Auth_Per_U00000L_System_Operation_StartDAL IV_Auth_Per_U00000L_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000L_System_Operation_StartDAL=new V_Auth_Per_U00000L_System_Operation_StartDAL();
				return iV_Auth_Per_U00000L_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000L_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 315 数据接口
		IV_Auth_Per_U00000L_System_Org_TreeDAL iV_Auth_Per_U00000L_System_Org_TreeDAL;
		public IV_Auth_Per_U00000L_System_Org_TreeDAL IV_Auth_Per_U00000L_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000L_System_Org_TreeDAL=new V_Auth_Per_U00000L_System_Org_TreeDAL();
				return iV_Auth_Per_U00000L_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000L_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 316 数据接口
		IV_Auth_Per_U00000L_System_Person_ReadwriteDAL iV_Auth_Per_U00000L_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000L_System_Person_ReadwriteDAL IV_Auth_Per_U00000L_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000L_System_Person_ReadwriteDAL=new V_Auth_Per_U00000L_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000L_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000L_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 317 数据接口
		IV_Auth_Per_U00000L_System_PersonClassDAL iV_Auth_Per_U00000L_System_PersonClassDAL;
		public IV_Auth_Per_U00000L_System_PersonClassDAL IV_Auth_Per_U00000L_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000L_System_PersonClassDAL==null)
					iV_Auth_Per_U00000L_System_PersonClassDAL=new V_Auth_Per_U00000L_System_PersonClassDAL();
				return iV_Auth_Per_U00000L_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000L_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 318 数据接口
		IV_Auth_Per_U00000M_System_BPM_StartDAL iV_Auth_Per_U00000M_System_BPM_StartDAL;
		public IV_Auth_Per_U00000M_System_BPM_StartDAL IV_Auth_Per_U00000M_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000M_System_BPM_StartDAL=new V_Auth_Per_U00000M_System_BPM_StartDAL();
				return iV_Auth_Per_U00000M_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000M_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 319 数据接口
		IV_Auth_Per_U00000M_System_Operation_StartDAL iV_Auth_Per_U00000M_System_Operation_StartDAL;
		public IV_Auth_Per_U00000M_System_Operation_StartDAL IV_Auth_Per_U00000M_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000M_System_Operation_StartDAL=new V_Auth_Per_U00000M_System_Operation_StartDAL();
				return iV_Auth_Per_U00000M_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000M_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 320 数据接口
		IV_Auth_Per_U00000M_System_Org_TreeDAL iV_Auth_Per_U00000M_System_Org_TreeDAL;
		public IV_Auth_Per_U00000M_System_Org_TreeDAL IV_Auth_Per_U00000M_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000M_System_Org_TreeDAL=new V_Auth_Per_U00000M_System_Org_TreeDAL();
				return iV_Auth_Per_U00000M_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000M_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 321 数据接口
		IV_Auth_Per_U00000M_System_Person_ReadwriteDAL iV_Auth_Per_U00000M_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000M_System_Person_ReadwriteDAL IV_Auth_Per_U00000M_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000M_System_Person_ReadwriteDAL=new V_Auth_Per_U00000M_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000M_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000M_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 322 数据接口
		IV_Auth_Per_U00000M_System_PersonClassDAL iV_Auth_Per_U00000M_System_PersonClassDAL;
		public IV_Auth_Per_U00000M_System_PersonClassDAL IV_Auth_Per_U00000M_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000M_System_PersonClassDAL==null)
					iV_Auth_Per_U00000M_System_PersonClassDAL=new V_Auth_Per_U00000M_System_PersonClassDAL();
				return iV_Auth_Per_U00000M_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000M_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 323 数据接口
		IV_Auth_Per_U00000O_System_BPM_StartDAL iV_Auth_Per_U00000O_System_BPM_StartDAL;
		public IV_Auth_Per_U00000O_System_BPM_StartDAL IV_Auth_Per_U00000O_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000O_System_BPM_StartDAL=new V_Auth_Per_U00000O_System_BPM_StartDAL();
				return iV_Auth_Per_U00000O_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000O_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 324 数据接口
		IV_Auth_Per_U00000O_System_Operation_StartDAL iV_Auth_Per_U00000O_System_Operation_StartDAL;
		public IV_Auth_Per_U00000O_System_Operation_StartDAL IV_Auth_Per_U00000O_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000O_System_Operation_StartDAL=new V_Auth_Per_U00000O_System_Operation_StartDAL();
				return iV_Auth_Per_U00000O_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000O_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 325 数据接口
		IV_Auth_Per_U00000O_System_Org_TreeDAL iV_Auth_Per_U00000O_System_Org_TreeDAL;
		public IV_Auth_Per_U00000O_System_Org_TreeDAL IV_Auth_Per_U00000O_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000O_System_Org_TreeDAL=new V_Auth_Per_U00000O_System_Org_TreeDAL();
				return iV_Auth_Per_U00000O_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000O_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 326 数据接口
		IV_Auth_Per_U00000O_System_Person_ReadwriteDAL iV_Auth_Per_U00000O_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000O_System_Person_ReadwriteDAL IV_Auth_Per_U00000O_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000O_System_Person_ReadwriteDAL=new V_Auth_Per_U00000O_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000O_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000O_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 327 数据接口
		IV_Auth_Per_U00000O_System_PersonClassDAL iV_Auth_Per_U00000O_System_PersonClassDAL;
		public IV_Auth_Per_U00000O_System_PersonClassDAL IV_Auth_Per_U00000O_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000O_System_PersonClassDAL==null)
					iV_Auth_Per_U00000O_System_PersonClassDAL=new V_Auth_Per_U00000O_System_PersonClassDAL();
				return iV_Auth_Per_U00000O_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000O_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 328 数据接口
		IV_Auth_Per_U00000P_System_BPM_StartDAL iV_Auth_Per_U00000P_System_BPM_StartDAL;
		public IV_Auth_Per_U00000P_System_BPM_StartDAL IV_Auth_Per_U00000P_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000P_System_BPM_StartDAL=new V_Auth_Per_U00000P_System_BPM_StartDAL();
				return iV_Auth_Per_U00000P_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000P_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 329 数据接口
		IV_Auth_Per_U00000P_System_Operation_StartDAL iV_Auth_Per_U00000P_System_Operation_StartDAL;
		public IV_Auth_Per_U00000P_System_Operation_StartDAL IV_Auth_Per_U00000P_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000P_System_Operation_StartDAL=new V_Auth_Per_U00000P_System_Operation_StartDAL();
				return iV_Auth_Per_U00000P_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000P_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 330 数据接口
		IV_Auth_Per_U00000P_System_Org_TreeDAL iV_Auth_Per_U00000P_System_Org_TreeDAL;
		public IV_Auth_Per_U00000P_System_Org_TreeDAL IV_Auth_Per_U00000P_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000P_System_Org_TreeDAL=new V_Auth_Per_U00000P_System_Org_TreeDAL();
				return iV_Auth_Per_U00000P_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000P_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 331 数据接口
		IV_Auth_Per_U00000P_System_Person_ReadwriteDAL iV_Auth_Per_U00000P_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000P_System_Person_ReadwriteDAL IV_Auth_Per_U00000P_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000P_System_Person_ReadwriteDAL=new V_Auth_Per_U00000P_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000P_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000P_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 332 数据接口
		IV_Auth_Per_U00000P_System_PersonClassDAL iV_Auth_Per_U00000P_System_PersonClassDAL;
		public IV_Auth_Per_U00000P_System_PersonClassDAL IV_Auth_Per_U00000P_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000P_System_PersonClassDAL==null)
					iV_Auth_Per_U00000P_System_PersonClassDAL=new V_Auth_Per_U00000P_System_PersonClassDAL();
				return iV_Auth_Per_U00000P_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000P_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 333 数据接口
		IV_Auth_Per_U00000R_System_BPM_StartDAL iV_Auth_Per_U00000R_System_BPM_StartDAL;
		public IV_Auth_Per_U00000R_System_BPM_StartDAL IV_Auth_Per_U00000R_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000R_System_BPM_StartDAL=new V_Auth_Per_U00000R_System_BPM_StartDAL();
				return iV_Auth_Per_U00000R_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000R_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 334 数据接口
		IV_Auth_Per_U00000R_System_Operation_StartDAL iV_Auth_Per_U00000R_System_Operation_StartDAL;
		public IV_Auth_Per_U00000R_System_Operation_StartDAL IV_Auth_Per_U00000R_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000R_System_Operation_StartDAL=new V_Auth_Per_U00000R_System_Operation_StartDAL();
				return iV_Auth_Per_U00000R_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000R_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 335 数据接口
		IV_Auth_Per_U00000R_System_Org_TreeDAL iV_Auth_Per_U00000R_System_Org_TreeDAL;
		public IV_Auth_Per_U00000R_System_Org_TreeDAL IV_Auth_Per_U00000R_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000R_System_Org_TreeDAL=new V_Auth_Per_U00000R_System_Org_TreeDAL();
				return iV_Auth_Per_U00000R_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000R_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 336 数据接口
		IV_Auth_Per_U00000R_System_Person_ReadwriteDAL iV_Auth_Per_U00000R_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000R_System_Person_ReadwriteDAL IV_Auth_Per_U00000R_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000R_System_Person_ReadwriteDAL=new V_Auth_Per_U00000R_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000R_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000R_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 337 数据接口
		IV_Auth_Per_U00000R_System_PersonClassDAL iV_Auth_Per_U00000R_System_PersonClassDAL;
		public IV_Auth_Per_U00000R_System_PersonClassDAL IV_Auth_Per_U00000R_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000R_System_PersonClassDAL==null)
					iV_Auth_Per_U00000R_System_PersonClassDAL=new V_Auth_Per_U00000R_System_PersonClassDAL();
				return iV_Auth_Per_U00000R_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000R_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 338 数据接口
		IV_Auth_Per_U00000S_System_BPM_StartDAL iV_Auth_Per_U00000S_System_BPM_StartDAL;
		public IV_Auth_Per_U00000S_System_BPM_StartDAL IV_Auth_Per_U00000S_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000S_System_BPM_StartDAL=new V_Auth_Per_U00000S_System_BPM_StartDAL();
				return iV_Auth_Per_U00000S_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000S_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 339 数据接口
		IV_Auth_Per_U00000S_System_Operation_StartDAL iV_Auth_Per_U00000S_System_Operation_StartDAL;
		public IV_Auth_Per_U00000S_System_Operation_StartDAL IV_Auth_Per_U00000S_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000S_System_Operation_StartDAL=new V_Auth_Per_U00000S_System_Operation_StartDAL();
				return iV_Auth_Per_U00000S_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000S_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 340 数据接口
		IV_Auth_Per_U00000S_System_Org_TreeDAL iV_Auth_Per_U00000S_System_Org_TreeDAL;
		public IV_Auth_Per_U00000S_System_Org_TreeDAL IV_Auth_Per_U00000S_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000S_System_Org_TreeDAL=new V_Auth_Per_U00000S_System_Org_TreeDAL();
				return iV_Auth_Per_U00000S_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000S_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 341 数据接口
		IV_Auth_Per_U00000S_System_Person_ReadwriteDAL iV_Auth_Per_U00000S_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000S_System_Person_ReadwriteDAL IV_Auth_Per_U00000S_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000S_System_Person_ReadwriteDAL=new V_Auth_Per_U00000S_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000S_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000S_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 342 数据接口
		IV_Auth_Per_U00000S_System_PersonClassDAL iV_Auth_Per_U00000S_System_PersonClassDAL;
		public IV_Auth_Per_U00000S_System_PersonClassDAL IV_Auth_Per_U00000S_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000S_System_PersonClassDAL==null)
					iV_Auth_Per_U00000S_System_PersonClassDAL=new V_Auth_Per_U00000S_System_PersonClassDAL();
				return iV_Auth_Per_U00000S_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000S_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 343 数据接口
		IV_Auth_Per_U00000T_System_BPM_StartDAL iV_Auth_Per_U00000T_System_BPM_StartDAL;
		public IV_Auth_Per_U00000T_System_BPM_StartDAL IV_Auth_Per_U00000T_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000T_System_BPM_StartDAL=new V_Auth_Per_U00000T_System_BPM_StartDAL();
				return iV_Auth_Per_U00000T_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000T_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 344 数据接口
		IV_Auth_Per_U00000T_System_Operation_StartDAL iV_Auth_Per_U00000T_System_Operation_StartDAL;
		public IV_Auth_Per_U00000T_System_Operation_StartDAL IV_Auth_Per_U00000T_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000T_System_Operation_StartDAL=new V_Auth_Per_U00000T_System_Operation_StartDAL();
				return iV_Auth_Per_U00000T_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000T_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 345 数据接口
		IV_Auth_Per_U00000T_System_Org_TreeDAL iV_Auth_Per_U00000T_System_Org_TreeDAL;
		public IV_Auth_Per_U00000T_System_Org_TreeDAL IV_Auth_Per_U00000T_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000T_System_Org_TreeDAL=new V_Auth_Per_U00000T_System_Org_TreeDAL();
				return iV_Auth_Per_U00000T_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000T_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 346 数据接口
		IV_Auth_Per_U00000T_System_Person_ReadwriteDAL iV_Auth_Per_U00000T_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000T_System_Person_ReadwriteDAL IV_Auth_Per_U00000T_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000T_System_Person_ReadwriteDAL=new V_Auth_Per_U00000T_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000T_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000T_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 347 数据接口
		IV_Auth_Per_U00000T_System_PersonClassDAL iV_Auth_Per_U00000T_System_PersonClassDAL;
		public IV_Auth_Per_U00000T_System_PersonClassDAL IV_Auth_Per_U00000T_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000T_System_PersonClassDAL==null)
					iV_Auth_Per_U00000T_System_PersonClassDAL=new V_Auth_Per_U00000T_System_PersonClassDAL();
				return iV_Auth_Per_U00000T_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000T_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 348 数据接口
		IV_Auth_Per_U00000U_System_BPM_StartDAL iV_Auth_Per_U00000U_System_BPM_StartDAL;
		public IV_Auth_Per_U00000U_System_BPM_StartDAL IV_Auth_Per_U00000U_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000U_System_BPM_StartDAL=new V_Auth_Per_U00000U_System_BPM_StartDAL();
				return iV_Auth_Per_U00000U_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000U_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 349 数据接口
		IV_Auth_Per_U00000U_System_Operation_StartDAL iV_Auth_Per_U00000U_System_Operation_StartDAL;
		public IV_Auth_Per_U00000U_System_Operation_StartDAL IV_Auth_Per_U00000U_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000U_System_Operation_StartDAL=new V_Auth_Per_U00000U_System_Operation_StartDAL();
				return iV_Auth_Per_U00000U_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000U_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 350 数据接口
		IV_Auth_Per_U00000U_System_Org_TreeDAL iV_Auth_Per_U00000U_System_Org_TreeDAL;
		public IV_Auth_Per_U00000U_System_Org_TreeDAL IV_Auth_Per_U00000U_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000U_System_Org_TreeDAL=new V_Auth_Per_U00000U_System_Org_TreeDAL();
				return iV_Auth_Per_U00000U_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000U_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 351 数据接口
		IV_Auth_Per_U00000U_System_Person_ReadwriteDAL iV_Auth_Per_U00000U_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000U_System_Person_ReadwriteDAL IV_Auth_Per_U00000U_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000U_System_Person_ReadwriteDAL=new V_Auth_Per_U00000U_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000U_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000U_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 352 数据接口
		IV_Auth_Per_U00000U_System_PersonClassDAL iV_Auth_Per_U00000U_System_PersonClassDAL;
		public IV_Auth_Per_U00000U_System_PersonClassDAL IV_Auth_Per_U00000U_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000U_System_PersonClassDAL==null)
					iV_Auth_Per_U00000U_System_PersonClassDAL=new V_Auth_Per_U00000U_System_PersonClassDAL();
				return iV_Auth_Per_U00000U_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000U_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 353 数据接口
		IV_Auth_Per_U00000V_System_BPM_StartDAL iV_Auth_Per_U00000V_System_BPM_StartDAL;
		public IV_Auth_Per_U00000V_System_BPM_StartDAL IV_Auth_Per_U00000V_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000V_System_BPM_StartDAL=new V_Auth_Per_U00000V_System_BPM_StartDAL();
				return iV_Auth_Per_U00000V_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000V_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 354 数据接口
		IV_Auth_Per_U00000V_System_Operation_StartDAL iV_Auth_Per_U00000V_System_Operation_StartDAL;
		public IV_Auth_Per_U00000V_System_Operation_StartDAL IV_Auth_Per_U00000V_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000V_System_Operation_StartDAL=new V_Auth_Per_U00000V_System_Operation_StartDAL();
				return iV_Auth_Per_U00000V_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000V_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 355 数据接口
		IV_Auth_Per_U00000V_System_Org_TreeDAL iV_Auth_Per_U00000V_System_Org_TreeDAL;
		public IV_Auth_Per_U00000V_System_Org_TreeDAL IV_Auth_Per_U00000V_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000V_System_Org_TreeDAL=new V_Auth_Per_U00000V_System_Org_TreeDAL();
				return iV_Auth_Per_U00000V_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000V_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 356 数据接口
		IV_Auth_Per_U00000V_System_Person_ReadwriteDAL iV_Auth_Per_U00000V_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000V_System_Person_ReadwriteDAL IV_Auth_Per_U00000V_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000V_System_Person_ReadwriteDAL=new V_Auth_Per_U00000V_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000V_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000V_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 357 数据接口
		IV_Auth_Per_U00000V_System_PersonClassDAL iV_Auth_Per_U00000V_System_PersonClassDAL;
		public IV_Auth_Per_U00000V_System_PersonClassDAL IV_Auth_Per_U00000V_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000V_System_PersonClassDAL==null)
					iV_Auth_Per_U00000V_System_PersonClassDAL=new V_Auth_Per_U00000V_System_PersonClassDAL();
				return iV_Auth_Per_U00000V_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000V_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 358 数据接口
		IV_Auth_Per_U00000X_System_BPM_StartDAL iV_Auth_Per_U00000X_System_BPM_StartDAL;
		public IV_Auth_Per_U00000X_System_BPM_StartDAL IV_Auth_Per_U00000X_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000X_System_BPM_StartDAL=new V_Auth_Per_U00000X_System_BPM_StartDAL();
				return iV_Auth_Per_U00000X_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000X_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 359 数据接口
		IV_Auth_Per_U00000X_System_Operation_StartDAL iV_Auth_Per_U00000X_System_Operation_StartDAL;
		public IV_Auth_Per_U00000X_System_Operation_StartDAL IV_Auth_Per_U00000X_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000X_System_Operation_StartDAL=new V_Auth_Per_U00000X_System_Operation_StartDAL();
				return iV_Auth_Per_U00000X_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000X_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 360 数据接口
		IV_Auth_Per_U00000X_System_Org_TreeDAL iV_Auth_Per_U00000X_System_Org_TreeDAL;
		public IV_Auth_Per_U00000X_System_Org_TreeDAL IV_Auth_Per_U00000X_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000X_System_Org_TreeDAL=new V_Auth_Per_U00000X_System_Org_TreeDAL();
				return iV_Auth_Per_U00000X_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000X_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 361 数据接口
		IV_Auth_Per_U00000X_System_Person_ReadwriteDAL iV_Auth_Per_U00000X_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000X_System_Person_ReadwriteDAL IV_Auth_Per_U00000X_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000X_System_Person_ReadwriteDAL=new V_Auth_Per_U00000X_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000X_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000X_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 362 数据接口
		IV_Auth_Per_U00000X_System_PersonClassDAL iV_Auth_Per_U00000X_System_PersonClassDAL;
		public IV_Auth_Per_U00000X_System_PersonClassDAL IV_Auth_Per_U00000X_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000X_System_PersonClassDAL==null)
					iV_Auth_Per_U00000X_System_PersonClassDAL=new V_Auth_Per_U00000X_System_PersonClassDAL();
				return iV_Auth_Per_U00000X_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000X_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 363 数据接口
		IV_Auth_Per_U00000Y_System_BPM_StartDAL iV_Auth_Per_U00000Y_System_BPM_StartDAL;
		public IV_Auth_Per_U00000Y_System_BPM_StartDAL IV_Auth_Per_U00000Y_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000Y_System_BPM_StartDAL=new V_Auth_Per_U00000Y_System_BPM_StartDAL();
				return iV_Auth_Per_U00000Y_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 364 数据接口
		IV_Auth_Per_U00000Y_System_Operation_StartDAL iV_Auth_Per_U00000Y_System_Operation_StartDAL;
		public IV_Auth_Per_U00000Y_System_Operation_StartDAL IV_Auth_Per_U00000Y_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000Y_System_Operation_StartDAL=new V_Auth_Per_U00000Y_System_Operation_StartDAL();
				return iV_Auth_Per_U00000Y_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 365 数据接口
		IV_Auth_Per_U00000Y_System_Org_TreeDAL iV_Auth_Per_U00000Y_System_Org_TreeDAL;
		public IV_Auth_Per_U00000Y_System_Org_TreeDAL IV_Auth_Per_U00000Y_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000Y_System_Org_TreeDAL=new V_Auth_Per_U00000Y_System_Org_TreeDAL();
				return iV_Auth_Per_U00000Y_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 366 数据接口
		IV_Auth_Per_U00000Y_System_Person_ReadwriteDAL iV_Auth_Per_U00000Y_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000Y_System_Person_ReadwriteDAL IV_Auth_Per_U00000Y_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000Y_System_Person_ReadwriteDAL=new V_Auth_Per_U00000Y_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000Y_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 367 数据接口
		IV_Auth_Per_U00000Y_System_PersonClassDAL iV_Auth_Per_U00000Y_System_PersonClassDAL;
		public IV_Auth_Per_U00000Y_System_PersonClassDAL IV_Auth_Per_U00000Y_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Y_System_PersonClassDAL==null)
					iV_Auth_Per_U00000Y_System_PersonClassDAL=new V_Auth_Per_U00000Y_System_PersonClassDAL();
				return iV_Auth_Per_U00000Y_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000Y_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 368 数据接口
		IV_Auth_Per_U00000Z_System_BPM_StartDAL iV_Auth_Per_U00000Z_System_BPM_StartDAL;
		public IV_Auth_Per_U00000Z_System_BPM_StartDAL IV_Auth_Per_U00000Z_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_BPM_StartDAL==null)
					iV_Auth_Per_U00000Z_System_BPM_StartDAL=new V_Auth_Per_U00000Z_System_BPM_StartDAL();
				return iV_Auth_Per_U00000Z_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 369 数据接口
		IV_Auth_Per_U00000Z_System_Operation_StartDAL iV_Auth_Per_U00000Z_System_Operation_StartDAL;
		public IV_Auth_Per_U00000Z_System_Operation_StartDAL IV_Auth_Per_U00000Z_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_Operation_StartDAL==null)
					iV_Auth_Per_U00000Z_System_Operation_StartDAL=new V_Auth_Per_U00000Z_System_Operation_StartDAL();
				return iV_Auth_Per_U00000Z_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 370 数据接口
		IV_Auth_Per_U00000Z_System_Org_TreeDAL iV_Auth_Per_U00000Z_System_Org_TreeDAL;
		public IV_Auth_Per_U00000Z_System_Org_TreeDAL IV_Auth_Per_U00000Z_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_Org_TreeDAL==null)
					iV_Auth_Per_U00000Z_System_Org_TreeDAL=new V_Auth_Per_U00000Z_System_Org_TreeDAL();
				return iV_Auth_Per_U00000Z_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 371 数据接口
		IV_Auth_Per_U00000Z_System_Person_ReadwriteDAL iV_Auth_Per_U00000Z_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U00000Z_System_Person_ReadwriteDAL IV_Auth_Per_U00000Z_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U00000Z_System_Person_ReadwriteDAL=new V_Auth_Per_U00000Z_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U00000Z_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 372 数据接口
		IV_Auth_Per_U00000Z_System_PersonClassDAL iV_Auth_Per_U00000Z_System_PersonClassDAL;
		public IV_Auth_Per_U00000Z_System_PersonClassDAL IV_Auth_Per_U00000Z_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U00000Z_System_PersonClassDAL==null)
					iV_Auth_Per_U00000Z_System_PersonClassDAL=new V_Auth_Per_U00000Z_System_PersonClassDAL();
				return iV_Auth_Per_U00000Z_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U00000Z_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 373 数据接口
		IV_Auth_Per_U000010_System_BPM_StartDAL iV_Auth_Per_U000010_System_BPM_StartDAL;
		public IV_Auth_Per_U000010_System_BPM_StartDAL IV_Auth_Per_U000010_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000010_System_BPM_StartDAL==null)
					iV_Auth_Per_U000010_System_BPM_StartDAL=new V_Auth_Per_U000010_System_BPM_StartDAL();
				return iV_Auth_Per_U000010_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000010_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 374 数据接口
		IV_Auth_Per_U000010_System_Operation_StartDAL iV_Auth_Per_U000010_System_Operation_StartDAL;
		public IV_Auth_Per_U000010_System_Operation_StartDAL IV_Auth_Per_U000010_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000010_System_Operation_StartDAL==null)
					iV_Auth_Per_U000010_System_Operation_StartDAL=new V_Auth_Per_U000010_System_Operation_StartDAL();
				return iV_Auth_Per_U000010_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000010_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 375 数据接口
		IV_Auth_Per_U000010_System_Org_TreeDAL iV_Auth_Per_U000010_System_Org_TreeDAL;
		public IV_Auth_Per_U000010_System_Org_TreeDAL IV_Auth_Per_U000010_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U000010_System_Org_TreeDAL==null)
					iV_Auth_Per_U000010_System_Org_TreeDAL=new V_Auth_Per_U000010_System_Org_TreeDAL();
				return iV_Auth_Per_U000010_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U000010_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 376 数据接口
		IV_Auth_Per_U000010_System_Person_ReadwriteDAL iV_Auth_Per_U000010_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U000010_System_Person_ReadwriteDAL IV_Auth_Per_U000010_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U000010_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U000010_System_Person_ReadwriteDAL=new V_Auth_Per_U000010_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U000010_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U000010_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 377 数据接口
		IV_Auth_Per_U000010_System_PersonClassDAL iV_Auth_Per_U000010_System_PersonClassDAL;
		public IV_Auth_Per_U000010_System_PersonClassDAL IV_Auth_Per_U000010_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U000010_System_PersonClassDAL==null)
					iV_Auth_Per_U000010_System_PersonClassDAL=new V_Auth_Per_U000010_System_PersonClassDAL();
				return iV_Auth_Per_U000010_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U000010_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 378 数据接口
		IV_Auth_Per_U000011_System_BPM_StartDAL iV_Auth_Per_U000011_System_BPM_StartDAL;
		public IV_Auth_Per_U000011_System_BPM_StartDAL IV_Auth_Per_U000011_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000011_System_BPM_StartDAL==null)
					iV_Auth_Per_U000011_System_BPM_StartDAL=new V_Auth_Per_U000011_System_BPM_StartDAL();
				return iV_Auth_Per_U000011_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000011_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 379 数据接口
		IV_Auth_Per_U000011_System_Operation_StartDAL iV_Auth_Per_U000011_System_Operation_StartDAL;
		public IV_Auth_Per_U000011_System_Operation_StartDAL IV_Auth_Per_U000011_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000011_System_Operation_StartDAL==null)
					iV_Auth_Per_U000011_System_Operation_StartDAL=new V_Auth_Per_U000011_System_Operation_StartDAL();
				return iV_Auth_Per_U000011_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000011_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 380 数据接口
		IV_Auth_Per_U000011_System_Org_TreeDAL iV_Auth_Per_U000011_System_Org_TreeDAL;
		public IV_Auth_Per_U000011_System_Org_TreeDAL IV_Auth_Per_U000011_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U000011_System_Org_TreeDAL==null)
					iV_Auth_Per_U000011_System_Org_TreeDAL=new V_Auth_Per_U000011_System_Org_TreeDAL();
				return iV_Auth_Per_U000011_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U000011_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 381 数据接口
		IV_Auth_Per_U000011_System_Person_ReadwriteDAL iV_Auth_Per_U000011_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U000011_System_Person_ReadwriteDAL IV_Auth_Per_U000011_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U000011_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U000011_System_Person_ReadwriteDAL=new V_Auth_Per_U000011_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U000011_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U000011_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 382 数据接口
		IV_Auth_Per_U000011_System_PersonClassDAL iV_Auth_Per_U000011_System_PersonClassDAL;
		public IV_Auth_Per_U000011_System_PersonClassDAL IV_Auth_Per_U000011_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U000011_System_PersonClassDAL==null)
					iV_Auth_Per_U000011_System_PersonClassDAL=new V_Auth_Per_U000011_System_PersonClassDAL();
				return iV_Auth_Per_U000011_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U000011_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 383 数据接口
		IV_Auth_Per_U000012_System_BPM_StartDAL iV_Auth_Per_U000012_System_BPM_StartDAL;
		public IV_Auth_Per_U000012_System_BPM_StartDAL IV_Auth_Per_U000012_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000012_System_BPM_StartDAL==null)
					iV_Auth_Per_U000012_System_BPM_StartDAL=new V_Auth_Per_U000012_System_BPM_StartDAL();
				return iV_Auth_Per_U000012_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000012_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 384 数据接口
		IV_Auth_Per_U000012_System_Operation_StartDAL iV_Auth_Per_U000012_System_Operation_StartDAL;
		public IV_Auth_Per_U000012_System_Operation_StartDAL IV_Auth_Per_U000012_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000012_System_Operation_StartDAL==null)
					iV_Auth_Per_U000012_System_Operation_StartDAL=new V_Auth_Per_U000012_System_Operation_StartDAL();
				return iV_Auth_Per_U000012_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000012_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 385 数据接口
		IV_Auth_Per_U000012_System_Org_TreeDAL iV_Auth_Per_U000012_System_Org_TreeDAL;
		public IV_Auth_Per_U000012_System_Org_TreeDAL IV_Auth_Per_U000012_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U000012_System_Org_TreeDAL==null)
					iV_Auth_Per_U000012_System_Org_TreeDAL=new V_Auth_Per_U000012_System_Org_TreeDAL();
				return iV_Auth_Per_U000012_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U000012_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 386 数据接口
		IV_Auth_Per_U000012_System_Person_ReadwriteDAL iV_Auth_Per_U000012_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U000012_System_Person_ReadwriteDAL IV_Auth_Per_U000012_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U000012_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U000012_System_Person_ReadwriteDAL=new V_Auth_Per_U000012_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U000012_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U000012_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 387 数据接口
		IV_Auth_Per_U000012_System_PersonClassDAL iV_Auth_Per_U000012_System_PersonClassDAL;
		public IV_Auth_Per_U000012_System_PersonClassDAL IV_Auth_Per_U000012_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U000012_System_PersonClassDAL==null)
					iV_Auth_Per_U000012_System_PersonClassDAL=new V_Auth_Per_U000012_System_PersonClassDAL();
				return iV_Auth_Per_U000012_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U000012_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 388 数据接口
		IV_Auth_Per_U000014_System_BPM_StartDAL iV_Auth_Per_U000014_System_BPM_StartDAL;
		public IV_Auth_Per_U000014_System_BPM_StartDAL IV_Auth_Per_U000014_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000014_System_BPM_StartDAL==null)
					iV_Auth_Per_U000014_System_BPM_StartDAL=new V_Auth_Per_U000014_System_BPM_StartDAL();
				return iV_Auth_Per_U000014_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000014_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 389 数据接口
		IV_Auth_Per_U000014_System_Operation_StartDAL iV_Auth_Per_U000014_System_Operation_StartDAL;
		public IV_Auth_Per_U000014_System_Operation_StartDAL IV_Auth_Per_U000014_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000014_System_Operation_StartDAL==null)
					iV_Auth_Per_U000014_System_Operation_StartDAL=new V_Auth_Per_U000014_System_Operation_StartDAL();
				return iV_Auth_Per_U000014_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000014_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 390 数据接口
		IV_Auth_Per_U000014_System_Org_TreeDAL iV_Auth_Per_U000014_System_Org_TreeDAL;
		public IV_Auth_Per_U000014_System_Org_TreeDAL IV_Auth_Per_U000014_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U000014_System_Org_TreeDAL==null)
					iV_Auth_Per_U000014_System_Org_TreeDAL=new V_Auth_Per_U000014_System_Org_TreeDAL();
				return iV_Auth_Per_U000014_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U000014_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 391 数据接口
		IV_Auth_Per_U000014_System_Person_ReadwriteDAL iV_Auth_Per_U000014_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U000014_System_Person_ReadwriteDAL IV_Auth_Per_U000014_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U000014_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U000014_System_Person_ReadwriteDAL=new V_Auth_Per_U000014_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U000014_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U000014_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 392 数据接口
		IV_Auth_Per_U000014_System_PersonClassDAL iV_Auth_Per_U000014_System_PersonClassDAL;
		public IV_Auth_Per_U000014_System_PersonClassDAL IV_Auth_Per_U000014_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U000014_System_PersonClassDAL==null)
					iV_Auth_Per_U000014_System_PersonClassDAL=new V_Auth_Per_U000014_System_PersonClassDAL();
				return iV_Auth_Per_U000014_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U000014_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 393 数据接口
		IV_Auth_Per_U000015_System_BPM_StartDAL iV_Auth_Per_U000015_System_BPM_StartDAL;
		public IV_Auth_Per_U000015_System_BPM_StartDAL IV_Auth_Per_U000015_System_BPM_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000015_System_BPM_StartDAL==null)
					iV_Auth_Per_U000015_System_BPM_StartDAL=new V_Auth_Per_U000015_System_BPM_StartDAL();
				return iV_Auth_Per_U000015_System_BPM_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000015_System_BPM_StartDAL=value;
			}
		}
		#endregion
			#region 394 数据接口
		IV_Auth_Per_U000015_System_Operation_StartDAL iV_Auth_Per_U000015_System_Operation_StartDAL;
		public IV_Auth_Per_U000015_System_Operation_StartDAL IV_Auth_Per_U000015_System_Operation_StartDAL
		{
			get
			{
				if(iV_Auth_Per_U000015_System_Operation_StartDAL==null)
					iV_Auth_Per_U000015_System_Operation_StartDAL=new V_Auth_Per_U000015_System_Operation_StartDAL();
				return iV_Auth_Per_U000015_System_Operation_StartDAL;
			}
			set
			{
				iV_Auth_Per_U000015_System_Operation_StartDAL=value;
			}
		}
		#endregion
			#region 395 数据接口
		IV_Auth_Per_U000015_System_Org_TreeDAL iV_Auth_Per_U000015_System_Org_TreeDAL;
		public IV_Auth_Per_U000015_System_Org_TreeDAL IV_Auth_Per_U000015_System_Org_TreeDAL
		{
			get
			{
				if(iV_Auth_Per_U000015_System_Org_TreeDAL==null)
					iV_Auth_Per_U000015_System_Org_TreeDAL=new V_Auth_Per_U000015_System_Org_TreeDAL();
				return iV_Auth_Per_U000015_System_Org_TreeDAL;
			}
			set
			{
				iV_Auth_Per_U000015_System_Org_TreeDAL=value;
			}
		}
		#endregion
			#region 396 数据接口
		IV_Auth_Per_U000015_System_Person_ReadwriteDAL iV_Auth_Per_U000015_System_Person_ReadwriteDAL;
		public IV_Auth_Per_U000015_System_Person_ReadwriteDAL IV_Auth_Per_U000015_System_Person_ReadwriteDAL
		{
			get
			{
				if(iV_Auth_Per_U000015_System_Person_ReadwriteDAL==null)
					iV_Auth_Per_U000015_System_Person_ReadwriteDAL=new V_Auth_Per_U000015_System_Person_ReadwriteDAL();
				return iV_Auth_Per_U000015_System_Person_ReadwriteDAL;
			}
			set
			{
				iV_Auth_Per_U000015_System_Person_ReadwriteDAL=value;
			}
		}
		#endregion
			#region 397 数据接口
		IV_Auth_Per_U000015_System_PersonClassDAL iV_Auth_Per_U000015_System_PersonClassDAL;
		public IV_Auth_Per_U000015_System_PersonClassDAL IV_Auth_Per_U000015_System_PersonClassDAL
		{
			get
			{
				if(iV_Auth_Per_U000015_System_PersonClassDAL==null)
					iV_Auth_Per_U000015_System_PersonClassDAL=new V_Auth_Per_U000015_System_PersonClassDAL();
				return iV_Auth_Per_U000015_System_PersonClassDAL;
			}
			set
			{
				iV_Auth_Per_U000015_System_PersonClassDAL=value;
			}
		}
		#endregion
			#region 398 数据接口
		IV_My_WidgetModule_ObjectsDAL iV_My_WidgetModule_ObjectsDAL;
		public IV_My_WidgetModule_ObjectsDAL IV_My_WidgetModule_ObjectsDAL
		{
			get
			{
				if(iV_My_WidgetModule_ObjectsDAL==null)
					iV_My_WidgetModule_ObjectsDAL=new V_My_WidgetModule_ObjectsDAL();
				return iV_My_WidgetModule_ObjectsDAL;
			}
			set
			{
				iV_My_WidgetModule_ObjectsDAL=value;
			}
		}
		#endregion
			#region 399 数据接口
		IView_A02DAL iView_A02DAL;
		public IView_A02DAL IView_A02DAL
		{
			get
			{
				if(iView_A02DAL==null)
					iView_A02DAL=new View_A02DAL();
				return iView_A02DAL;
			}
			set
			{
				iView_A02DAL=value;
			}
		}
		#endregion
			#region 400 数据接口
		IView_Auth_UserDAL iView_Auth_UserDAL;
		public IView_Auth_UserDAL IView_Auth_UserDAL
		{
			get
			{
				if(iView_Auth_UserDAL==null)
					iView_Auth_UserDAL=new View_Auth_UserDAL();
				return iView_Auth_UserDAL;
			}
			set
			{
				iView_Auth_UserDAL=value;
			}
		}
		#endregion
			#region 401 数据接口
		IView_CatalogDocumentDAL iView_CatalogDocumentDAL;
		public IView_CatalogDocumentDAL IView_CatalogDocumentDAL
		{
			get
			{
				if(iView_CatalogDocumentDAL==null)
					iView_CatalogDocumentDAL=new View_CatalogDocumentDAL();
				return iView_CatalogDocumentDAL;
			}
			set
			{
				iView_CatalogDocumentDAL=value;
			}
		}
		#endregion
			#region 402 数据接口
		IView_Com_JetTableItemsDAL iView_Com_JetTableItemsDAL;
		public IView_Com_JetTableItemsDAL IView_Com_JetTableItemsDAL
		{
			get
			{
				if(iView_Com_JetTableItemsDAL==null)
					iView_Com_JetTableItemsDAL=new View_Com_JetTableItemsDAL();
				return iView_Com_JetTableItemsDAL;
			}
			set
			{
				iView_Com_JetTableItemsDAL=value;
			}
		}
		#endregion
			#region 403 数据接口
		IView_QXTJDAL iView_QXTJDAL;
		public IView_QXTJDAL IView_QXTJDAL
		{
			get
			{
				if(iView_QXTJDAL==null)
					iView_QXTJDAL=new View_QXTJDAL();
				return iView_QXTJDAL;
			}
			set
			{
				iView_QXTJDAL=value;
			}
		}
		#endregion
			#region 404 数据接口
		IWF_JobMainDAL iWF_JobMainDAL;
		public IWF_JobMainDAL IWF_JobMainDAL
		{
			get
			{
				if(iWF_JobMainDAL==null)
					iWF_JobMainDAL=new WF_JobMainDAL();
				return iWF_JobMainDAL;
			}
			set
			{
				iWF_JobMainDAL=value;
			}
		}
		#endregion
			#region 405 数据接口
		IWF_JobMainExcludeChooseDAL iWF_JobMainExcludeChooseDAL;
		public IWF_JobMainExcludeChooseDAL IWF_JobMainExcludeChooseDAL
		{
			get
			{
				if(iWF_JobMainExcludeChooseDAL==null)
					iWF_JobMainExcludeChooseDAL=new WF_JobMainExcludeChooseDAL();
				return iWF_JobMainExcludeChooseDAL;
			}
			set
			{
				iWF_JobMainExcludeChooseDAL=value;
			}
		}
		#endregion
			#region 406 数据接口
		IWF_JobOpinionDAL iWF_JobOpinionDAL;
		public IWF_JobOpinionDAL IWF_JobOpinionDAL
		{
			get
			{
				if(iWF_JobOpinionDAL==null)
					iWF_JobOpinionDAL=new WF_JobOpinionDAL();
				return iWF_JobOpinionDAL;
			}
			set
			{
				iWF_JobOpinionDAL=value;
			}
		}
		#endregion
			#region 407 数据接口
		IWF_JobProxyDAL iWF_JobProxyDAL;
		public IWF_JobProxyDAL IWF_JobProxyDAL
		{
			get
			{
				if(iWF_JobProxyDAL==null)
					iWF_JobProxyDAL=new WF_JobProxyDAL();
				return iWF_JobProxyDAL;
			}
			set
			{
				iWF_JobProxyDAL=value;
			}
		}
		#endregion
			#region 408 数据接口
		IWF_JobSaveOrgDAL iWF_JobSaveOrgDAL;
		public IWF_JobSaveOrgDAL IWF_JobSaveOrgDAL
		{
			get
			{
				if(iWF_JobSaveOrgDAL==null)
					iWF_JobSaveOrgDAL=new WF_JobSaveOrgDAL();
				return iWF_JobSaveOrgDAL;
			}
			set
			{
				iWF_JobSaveOrgDAL=value;
			}
		}
		#endregion
			#region 409 数据接口
		IWF_JobStepDAL iWF_JobStepDAL;
		public IWF_JobStepDAL IWF_JobStepDAL
		{
			get
			{
				if(iWF_JobStepDAL==null)
					iWF_JobStepDAL=new WF_JobStepDAL();
				return iWF_JobStepDAL;
			}
			set
			{
				iWF_JobStepDAL=value;
			}
		}
		#endregion
			#region 410 数据接口
		IWF_OperationCalcDAL iWF_OperationCalcDAL;
		public IWF_OperationCalcDAL IWF_OperationCalcDAL
		{
			get
			{
				if(iWF_OperationCalcDAL==null)
					iWF_OperationCalcDAL=new WF_OperationCalcDAL();
				return iWF_OperationCalcDAL;
			}
			set
			{
				iWF_OperationCalcDAL=value;
			}
		}
		#endregion
			#region 411 数据接口
		IWF_OperationDocumentDAL iWF_OperationDocumentDAL;
		public IWF_OperationDocumentDAL IWF_OperationDocumentDAL
		{
			get
			{
				if(iWF_OperationDocumentDAL==null)
					iWF_OperationDocumentDAL=new WF_OperationDocumentDAL();
				return iWF_OperationDocumentDAL;
			}
			set
			{
				iWF_OperationDocumentDAL=value;
			}
		}
		#endregion
			#region 412 数据接口
		IWF_OperationGroupDAL iWF_OperationGroupDAL;
		public IWF_OperationGroupDAL IWF_OperationGroupDAL
		{
			get
			{
				if(iWF_OperationGroupDAL==null)
					iWF_OperationGroupDAL=new WF_OperationGroupDAL();
				return iWF_OperationGroupDAL;
			}
			set
			{
				iWF_OperationGroupDAL=value;
			}
		}
		#endregion
			#region 413 数据接口
		IWF_OperationKeyValueDAL iWF_OperationKeyValueDAL;
		public IWF_OperationKeyValueDAL IWF_OperationKeyValueDAL
		{
			get
			{
				if(iWF_OperationKeyValueDAL==null)
					iWF_OperationKeyValueDAL=new WF_OperationKeyValueDAL();
				return iWF_OperationKeyValueDAL;
			}
			set
			{
				iWF_OperationKeyValueDAL=value;
			}
		}
		#endregion
			#region 414 数据接口
		IWF_OperationMainDAL iWF_OperationMainDAL;
		public IWF_OperationMainDAL IWF_OperationMainDAL
		{
			get
			{
				if(iWF_OperationMainDAL==null)
					iWF_OperationMainDAL=new WF_OperationMainDAL();
				return iWF_OperationMainDAL;
			}
			set
			{
				iWF_OperationMainDAL=value;
			}
		}
		#endregion
			#region 415 数据接口
		IWF_OperationOutPutDAL iWF_OperationOutPutDAL;
		public IWF_OperationOutPutDAL IWF_OperationOutPutDAL
		{
			get
			{
				if(iWF_OperationOutPutDAL==null)
					iWF_OperationOutPutDAL=new WF_OperationOutPutDAL();
				return iWF_OperationOutPutDAL;
			}
			set
			{
				iWF_OperationOutPutDAL=value;
			}
		}
		#endregion
			#region 416 数据接口
		IWF_OperationSalaryOPItemDAL iWF_OperationSalaryOPItemDAL;
		public IWF_OperationSalaryOPItemDAL IWF_OperationSalaryOPItemDAL
		{
			get
			{
				if(iWF_OperationSalaryOPItemDAL==null)
					iWF_OperationSalaryOPItemDAL=new WF_OperationSalaryOPItemDAL();
				return iWF_OperationSalaryOPItemDAL;
			}
			set
			{
				iWF_OperationSalaryOPItemDAL=value;
			}
		}
		#endregion
			#region 417 数据接口
		IWF_OperationSalaryOPMainDAL iWF_OperationSalaryOPMainDAL;
		public IWF_OperationSalaryOPMainDAL IWF_OperationSalaryOPMainDAL
		{
			get
			{
				if(iWF_OperationSalaryOPMainDAL==null)
					iWF_OperationSalaryOPMainDAL=new WF_OperationSalaryOPMainDAL();
				return iWF_OperationSalaryOPMainDAL;
			}
			set
			{
				iWF_OperationSalaryOPMainDAL=value;
			}
		}
		#endregion
			#region 418 数据接口
		IWF_OperationSalaryOPSignItemDAL iWF_OperationSalaryOPSignItemDAL;
		public IWF_OperationSalaryOPSignItemDAL IWF_OperationSalaryOPSignItemDAL
		{
			get
			{
				if(iWF_OperationSalaryOPSignItemDAL==null)
					iWF_OperationSalaryOPSignItemDAL=new WF_OperationSalaryOPSignItemDAL();
				return iWF_OperationSalaryOPSignItemDAL;
			}
			set
			{
				iWF_OperationSalaryOPSignItemDAL=value;
			}
		}
		#endregion
			#region 419 数据接口
		IWF_OperationSalaryOPSignMainDAL iWF_OperationSalaryOPSignMainDAL;
		public IWF_OperationSalaryOPSignMainDAL IWF_OperationSalaryOPSignMainDAL
		{
			get
			{
				if(iWF_OperationSalaryOPSignMainDAL==null)
					iWF_OperationSalaryOPSignMainDAL=new WF_OperationSalaryOPSignMainDAL();
				return iWF_OperationSalaryOPSignMainDAL;
			}
			set
			{
				iWF_OperationSalaryOPSignMainDAL=value;
			}
		}
		#endregion
			#region 420 数据接口
		IWF_OperationSetItemOptionDAL iWF_OperationSetItemOptionDAL;
		public IWF_OperationSetItemOptionDAL IWF_OperationSetItemOptionDAL
		{
			get
			{
				if(iWF_OperationSetItemOptionDAL==null)
					iWF_OperationSetItemOptionDAL=new WF_OperationSetItemOptionDAL();
				return iWF_OperationSetItemOptionDAL;
			}
			set
			{
				iWF_OperationSetItemOptionDAL=value;
			}
		}
		#endregion
			#region 421 数据接口
		IWF_OperationSetItemsDAL iWF_OperationSetItemsDAL;
		public IWF_OperationSetItemsDAL IWF_OperationSetItemsDAL
		{
			get
			{
				if(iWF_OperationSetItemsDAL==null)
					iWF_OperationSetItemsDAL=new WF_OperationSetItemsDAL();
				return iWF_OperationSetItemsDAL;
			}
			set
			{
				iWF_OperationSetItemsDAL=value;
			}
		}
		#endregion
			#region 422 数据接口
		IWF_OperationSetTableDAL iWF_OperationSetTableDAL;
		public IWF_OperationSetTableDAL IWF_OperationSetTableDAL
		{
			get
			{
				if(iWF_OperationSetTableDAL==null)
					iWF_OperationSetTableDAL=new WF_OperationSetTableDAL();
				return iWF_OperationSetTableDAL;
			}
			set
			{
				iWF_OperationSetTableDAL=value;
			}
		}
		#endregion
			#region 423 数据接口
		IWF_OperationSetTableOptionDAL iWF_OperationSetTableOptionDAL;
		public IWF_OperationSetTableOptionDAL IWF_OperationSetTableOptionDAL
		{
			get
			{
				if(iWF_OperationSetTableOptionDAL==null)
					iWF_OperationSetTableOptionDAL=new WF_OperationSetTableOptionDAL();
				return iWF_OperationSetTableOptionDAL;
			}
			set
			{
				iWF_OperationSetTableOptionDAL=value;
			}
		}
		#endregion
			#region 424 数据接口
		IWF_OperationSTCodeItemsDAL iWF_OperationSTCodeItemsDAL;
		public IWF_OperationSTCodeItemsDAL IWF_OperationSTCodeItemsDAL
		{
			get
			{
				if(iWF_OperationSTCodeItemsDAL==null)
					iWF_OperationSTCodeItemsDAL=new WF_OperationSTCodeItemsDAL();
				return iWF_OperationSTCodeItemsDAL;
			}
			set
			{
				iWF_OperationSTCodeItemsDAL=value;
			}
		}
		#endregion
			#region 425 数据接口
		IWF_OperationSTDataDAL iWF_OperationSTDataDAL;
		public IWF_OperationSTDataDAL IWF_OperationSTDataDAL
		{
			get
			{
				if(iWF_OperationSTDataDAL==null)
					iWF_OperationSTDataDAL=new WF_OperationSTDataDAL();
				return iWF_OperationSTDataDAL;
			}
			set
			{
				iWF_OperationSTDataDAL=value;
			}
		}
		#endregion
			#region 426 数据接口
		IWF_OperationStepDAL iWF_OperationStepDAL;
		public IWF_OperationStepDAL IWF_OperationStepDAL
		{
			get
			{
				if(iWF_OperationStepDAL==null)
					iWF_OperationStepDAL=new WF_OperationStepDAL();
				return iWF_OperationStepDAL;
			}
			set
			{
				iWF_OperationStepDAL=value;
			}
		}
		#endregion
			#region 427 数据接口
		IWF_OperationStepPrivilegeDAL iWF_OperationStepPrivilegeDAL;
		public IWF_OperationStepPrivilegeDAL IWF_OperationStepPrivilegeDAL
		{
			get
			{
				if(iWF_OperationStepPrivilegeDAL==null)
					iWF_OperationStepPrivilegeDAL=new WF_OperationStepPrivilegeDAL();
				return iWF_OperationStepPrivilegeDAL;
			}
			set
			{
				iWF_OperationStepPrivilegeDAL=value;
			}
		}
		#endregion
			#region 428 数据接口
		IWF_OperationSTMainDAL iWF_OperationSTMainDAL;
		public IWF_OperationSTMainDAL IWF_OperationSTMainDAL
		{
			get
			{
				if(iWF_OperationSTMainDAL==null)
					iWF_OperationSTMainDAL=new WF_OperationSTMainDAL();
				return iWF_OperationSTMainDAL;
			}
			set
			{
				iWF_OperationSTMainDAL=value;
			}
		}
		#endregion
			#region 429 数据接口
		IWF_OperationSTSetItemsDAL iWF_OperationSTSetItemsDAL;
		public IWF_OperationSTSetItemsDAL IWF_OperationSTSetItemsDAL
		{
			get
			{
				if(iWF_OperationSTSetItemsDAL==null)
					iWF_OperationSTSetItemsDAL=new WF_OperationSTSetItemsDAL();
				return iWF_OperationSTSetItemsDAL;
			}
			set
			{
				iWF_OperationSTSetItemsDAL=value;
			}
		}
		#endregion
			#region 430 数据接口
		IWF_OperationTypeDAL iWF_OperationTypeDAL;
		public IWF_OperationTypeDAL IWF_OperationTypeDAL
		{
			get
			{
				if(iWF_OperationTypeDAL==null)
					iWF_OperationTypeDAL=new WF_OperationTypeDAL();
				return iWF_OperationTypeDAL;
			}
			set
			{
				iWF_OperationTypeDAL=value;
			}
		}
		#endregion
			#region 431 数据接口
		IWGJG_GRZXDAL iWGJG_GRZXDAL;
		public IWGJG_GRZXDAL IWGJG_GRZXDAL
		{
			get
			{
				if(iWGJG_GRZXDAL==null)
					iWGJG_GRZXDAL=new WGJG_GRZXDAL();
				return iWGJG_GRZXDAL;
			}
			set
			{
				iWGJG_GRZXDAL=value;
			}
		}
		#endregion
			#region 432 数据接口
		IWGJG_WarnDataDAL iWGJG_WarnDataDAL;
		public IWGJG_WarnDataDAL IWGJG_WarnDataDAL
		{
			get
			{
				if(iWGJG_WarnDataDAL==null)
					iWGJG_WarnDataDAL=new WGJG_WarnDataDAL();
				return iWGJG_WarnDataDAL;
			}
			set
			{
				iWGJG_WarnDataDAL=value;
			}
		}
		#endregion
			#region 433 数据接口
		IWGJG_ZXDAL iWGJG_ZXDAL;
		public IWGJG_ZXDAL IWGJG_ZXDAL
		{
			get
			{
				if(iWGJG_ZXDAL==null)
					iWGJG_ZXDAL=new WGJG_ZXDAL();
				return iWGJG_ZXDAL;
			}
			set
			{
				iWGJG_ZXDAL=value;
			}
		}
		#endregion
			#region 434 数据接口
		IWGJG01DAL iWGJG01DAL;
		public IWGJG01DAL IWGJG01DAL
		{
			get
			{
				if(iWGJG01DAL==null)
					iWGJG01DAL=new WGJG01DAL();
				return iWGJG01DAL;
			}
			set
			{
				iWGJG01DAL=value;
			}
		}
		#endregion
			#region 435 数据接口
		IWGJG01_TemplateDAL iWGJG01_TemplateDAL;
		public IWGJG01_TemplateDAL IWGJG01_TemplateDAL
		{
			get
			{
				if(iWGJG01_TemplateDAL==null)
					iWGJG01_TemplateDAL=new WGJG01_TemplateDAL();
				return iWGJG01_TemplateDAL;
			}
			set
			{
				iWGJG01_TemplateDAL=value;
			}
		}
		#endregion
			#region 436 数据接口
		IWGJG02DAL iWGJG02DAL;
		public IWGJG02DAL IWGJG02DAL
		{
			get
			{
				if(iWGJG02DAL==null)
					iWGJG02DAL=new WGJG02DAL();
				return iWGJG02DAL;
			}
			set
			{
				iWGJG02DAL=value;
			}
		}
		#endregion
			#region 437 数据接口
		IWGJG02_TemplateDAL iWGJG02_TemplateDAL;
		public IWGJG02_TemplateDAL IWGJG02_TemplateDAL
		{
			get
			{
				if(iWGJG02_TemplateDAL==null)
					iWGJG02_TemplateDAL=new WGJG02_TemplateDAL();
				return iWGJG02_TemplateDAL;
			}
			set
			{
				iWGJG02_TemplateDAL=value;
			}
		}
		#endregion
			#region 438 数据接口
		IXS_StudentDAL iXS_StudentDAL;
		public IXS_StudentDAL IXS_StudentDAL
		{
			get
			{
				if(iXS_StudentDAL==null)
					iXS_StudentDAL=new XS_StudentDAL();
				return iXS_StudentDAL;
			}
			set
			{
				iXS_StudentDAL=value;
			}
		}
		#endregion
			#region 439 数据接口
		IXS_StudentScoreDAL iXS_StudentScoreDAL;
		public IXS_StudentScoreDAL IXS_StudentScoreDAL
		{
			get
			{
				if(iXS_StudentScoreDAL==null)
					iXS_StudentScoreDAL=new XS_StudentScoreDAL();
				return iXS_StudentScoreDAL;
			}
			set
			{
				iXS_StudentScoreDAL=value;
			}
		}
		#endregion
	}
}