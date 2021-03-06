using System;
using NetRuntimeSystem = System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using NetOffice;
namespace NetOffice.MSProjectApi
{
	///<summary>
	/// DispatchInterface ViewCombination 
	/// SupportByVersion MSProject, 11,12,14
	///</summary>
	[SupportByVersionAttribute("MSProject", 11,12,14)]
	[EntityTypeAttribute(EntityType.IsDispatchInterface)]
	public class ViewCombination : View
	{
		#pragma warning disable
		#region Type Information

        private static Type _type;

		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public static Type LateBindingApiWrapperType
        {
            get
            {
                if (null == _type)
                    _type = typeof(ViewCombination);
                    
                return _type;
            }
        }
        
        #endregion
        
		#region Construction

        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public ViewCombination(COMObject parentObject, object comProxy) : base(parentObject, comProxy)
		{
		}
		
		/// <param name="parentObject">object there has created the proxy</param>
        /// <param name="comProxy">inner wrapped COM proxy</param>
        /// <param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public ViewCombination(COMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
		{
		}
		
		/// <param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public ViewCombination(COMObject replacedObject) : base(replacedObject)
		{
		}
		
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public ViewCombination() : base()
		{
		}
		
		/// <param name="progId">registered ProgID</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public ViewCombination(string progId) : base(progId)
		{
		}
		
		#endregion
		
		#region Properties

		/// <summary>
		/// SupportByVersion MSProject 11, 12, 14
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("MSProject", 11,12,14)]
		public NetOffice.MSProjectApi.ViewSingle TopView
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "TopView", paramsArray);
				NetOffice.MSProjectApi.ViewSingle newObject = NetOffice.Factory.CreateKnownObjectFromComProxy(this,returnItem,NetOffice.MSProjectApi.ViewSingle.LateBindingApiWrapperType) as NetOffice.MSProjectApi.ViewSingle;
				return newObject;
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "TopView", paramsArray);
			}
		}

		/// <summary>
		/// SupportByVersion MSProject 11, 12, 14
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("MSProject", 11,12,14)]
		public NetOffice.MSProjectApi.ViewSingle BottomView
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "BottomView", paramsArray);
				NetOffice.MSProjectApi.ViewSingle newObject = NetOffice.Factory.CreateKnownObjectFromComProxy(this,returnItem,NetOffice.MSProjectApi.ViewSingle.LateBindingApiWrapperType) as NetOffice.MSProjectApi.ViewSingle;
				return newObject;
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "BottomView", paramsArray);
			}
		}

		#endregion

		#region Methods

		#endregion
		#pragma warning restore
	}
}