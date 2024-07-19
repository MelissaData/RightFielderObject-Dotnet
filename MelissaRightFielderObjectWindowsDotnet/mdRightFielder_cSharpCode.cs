using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace MelissaData {
	public class mdRightFielder : IDisposable {
		private IntPtr i;

		public enum ProgramStatus {
			NoError = 0,
			ConfigFile = 1,
			LicenseExpired = 2,
			Unknown = 4
		}
		public enum Delimiter {
			Tab = 0,
			Comma = 1,
			Pipe = 2,
			CRLF = 3
		}
		public enum ResultCdDescOpt {
			ResultCodeDescriptionLong = 0,
			ResultCodeDescriptionShort = 1
		}

		[SuppressUnmanagedCodeSecurity]
		private class mdRightFielderUnmanaged {
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderCreate();
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderDestroy(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderSetLicenseString(IntPtr i, IntPtr p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetPathToRightFielderFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetPathToRightFielderFiles(IntPtr i, IntPtr p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetBuildNumber(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetDatabaseDate(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetLicenseExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetLicenseExpirationDate(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderInitializeDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderInitializeDataFiles(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetInitializeErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetInitializeErrorString(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetDelimiter", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetDelimiter(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetAcceptFullName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptFullName(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetAcceptDepartment", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptDepartment(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetAcceptCompany", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptCompany(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetAcceptAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptAddress(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetAcceptCityStateZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptCityStateZip(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetAcceptCountry", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptCountry(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetAcceptPhone", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptPhone(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetAcceptEmail", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptEmail(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetAcceptURL", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptURL(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetUserPattern", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderSetUserPattern(IntPtr i, IntPtr p1, IntPtr p2);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderParse", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderParse(IntPtr i, IntPtr p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderParseFreeForm", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderParseFreeForm(IntPtr i, IntPtr p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderParseFielded", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderParseFielded(IntPtr i, IntPtr p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetFullName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetFullName(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetFullNameNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetFullNameNext(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetDepartment", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetDepartment(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetDepartmentNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetDepartmentNext(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetCompany", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetCompany(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetCompanyNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetCompanyNext(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetAddress(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetAddress2", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetAddress2(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetAddress3", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetAddress3(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetCity", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetCity(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetState", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetState(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetPostalCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetPostalCode(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetCountry", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetCountry(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetLastLine", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetLastLine(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetPhone", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetPhone(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetPhoneNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetPhoneNext(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetPhoneType", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetPhoneType(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetPhoneTypeNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetPhoneTypeNext(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetEmail", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetEmail(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetEmailNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetEmailNext(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetURL", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetURL(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetURLNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetURLNext(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetUserField", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetUserField(IntPtr i, IntPtr p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetUserFieldNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetUserFieldNext(IntPtr i, IntPtr p1);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetUnrecognized", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetUnrecognized(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetUnrecognizedNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetUnrecognizedNext(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetResults", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetResults(IntPtr i);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetResultCodeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetResultCodeDescription(IntPtr i, IntPtr resultCode, Int32 opt);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderSetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetReserved(IntPtr i, IntPtr p1, IntPtr p2);
			[DllImport("mdRightFielder", EntryPoint = "mdRightFielderGetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetReserved(IntPtr i, IntPtr p1);
		}

		public mdRightFielder() {
			i = mdRightFielderUnmanaged.mdRightFielderCreate();
		}

		~mdRightFielder() {
			Dispose();
		}

		public virtual void Dispose() {
			lock (this) {
				mdRightFielderUnmanaged.mdRightFielderDestroy(i);
				GC.SuppressFinalize(this);
			}
		}

		public bool SetLicenseString(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdRightFielderUnmanaged.mdRightFielderSetLicenseString(i, u_p1.GetPtr()) != 0);
		}

		public void SetPathToRightFielderFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdRightFielderUnmanaged.mdRightFielderSetPathToRightFielderFiles(i, u_p1.GetPtr());
		}

		public string GetBuildNumber() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetBuildNumber(i));
		}

		public string GetDatabaseDate() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetDatabaseDate(i));
		}

		public string GetLicenseExpirationDate() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetLicenseExpirationDate(i));
		}

		public ProgramStatus InitializeDataFiles() {
			return (ProgramStatus)mdRightFielderUnmanaged.mdRightFielderInitializeDataFiles(i);
		}

		public string GetInitializeErrorString() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetInitializeErrorString(i));
		}

		public void SetDelimiter(Delimiter p1) {
			mdRightFielderUnmanaged.mdRightFielderSetDelimiter(i, (int)p1);
		}

		public void SetAcceptFullName(bool p1) {
			mdRightFielderUnmanaged.mdRightFielderSetAcceptFullName(i, (p1 ? 1 : 0));
		}

		public void SetAcceptDepartment(bool p1) {
			mdRightFielderUnmanaged.mdRightFielderSetAcceptDepartment(i, (p1 ? 1 : 0));
		}

		public void SetAcceptCompany(bool p1) {
			mdRightFielderUnmanaged.mdRightFielderSetAcceptCompany(i, (p1 ? 1 : 0));
		}

		public void SetAcceptAddress(bool p1) {
			mdRightFielderUnmanaged.mdRightFielderSetAcceptAddress(i, (p1 ? 1 : 0));
		}

		public void SetAcceptCityStateZip(bool p1) {
			mdRightFielderUnmanaged.mdRightFielderSetAcceptCityStateZip(i, (p1 ? 1 : 0));
		}

		public void SetAcceptCountry(bool p1) {
			mdRightFielderUnmanaged.mdRightFielderSetAcceptCountry(i, (p1 ? 1 : 0));
		}

		public void SetAcceptPhone(bool p1) {
			mdRightFielderUnmanaged.mdRightFielderSetAcceptPhone(i, (p1 ? 1 : 0));
		}

		public void SetAcceptEmail(bool p1) {
			mdRightFielderUnmanaged.mdRightFielderSetAcceptEmail(i, (p1 ? 1 : 0));
		}

		public void SetAcceptURL(bool p1) {
			mdRightFielderUnmanaged.mdRightFielderSetAcceptURL(i, (p1 ? 1 : 0));
		}

		public bool SetUserPattern(string p1, string p2) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			return (mdRightFielderUnmanaged.mdRightFielderSetUserPattern(i, u_p1.GetPtr(), u_p2.GetPtr()) != 0);
		}

		public bool Parse(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdRightFielderUnmanaged.mdRightFielderParse(i, u_p1.GetPtr()) != 0);
		}

		public bool ParseFreeForm(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdRightFielderUnmanaged.mdRightFielderParseFreeForm(i, u_p1.GetPtr()) != 0);
		}

		public bool ParseFielded(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdRightFielderUnmanaged.mdRightFielderParseFielded(i, u_p1.GetPtr()) != 0);
		}

		public string GetFullName() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetFullName(i));
		}

		public bool GetFullNameNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetFullNameNext(i) != 0);
		}

		public string GetDepartment() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetDepartment(i));
		}

		public bool GetDepartmentNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetDepartmentNext(i) != 0);
		}

		public string GetCompany() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetCompany(i));
		}

		public bool GetCompanyNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetCompanyNext(i) != 0);
		}

		public string GetAddress() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetAddress(i));
		}

		public string GetAddress2() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetAddress2(i));
		}

		public string GetAddress3() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetAddress3(i));
		}

		public string GetCity() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetCity(i));
		}

		public string GetState() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetState(i));
		}

		public string GetPostalCode() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetPostalCode(i));
		}

		public string GetCountry() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetCountry(i));
		}

		public string GetLastLine() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetLastLine(i));
		}

		public string GetPhone() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetPhone(i));
		}

		public bool GetPhoneNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetPhoneNext(i) != 0);
		}

		public string GetPhoneType() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetPhoneType(i));
		}

		public bool GetPhoneTypeNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetPhoneTypeNext(i) != 0);
		}

		public string GetEmail() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetEmail(i));
		}

		public bool GetEmailNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetEmailNext(i) != 0);
		}

		public string GetURL() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetURL(i));
		}

		public bool GetURLNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetURLNext(i) != 0);
		}

		public string GetUserField(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetUserField(i, u_p1.GetPtr()));
		}

		public bool GetUserFieldNext(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return (mdRightFielderUnmanaged.mdRightFielderGetUserFieldNext(i, u_p1.GetPtr()) != 0);
		}

		public string GetUnrecognized() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetUnrecognized(i));
		}

		public bool GetUnrecognizedNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetUnrecognizedNext(i) != 0);
		}

		public string GetResults() {
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetResults(i));
		}

		public string GetResultCodeDescription(string resultCode, ResultCdDescOpt opt) {
			EncodedString u_resultCode = new EncodedString(resultCode);
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetResultCodeDescription(i, u_resultCode.GetPtr(), (int)opt));
		}

		public string GetResultCodeDescription(string resultCode) {
			EncodedString u_resultCode = new EncodedString(resultCode);
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetResultCodeDescription(i, u_resultCode.GetPtr(), (int)ResultCdDescOpt.ResultCodeDescriptionLong));
		}

		public void SetReserved(string p1, string p2) {
			EncodedString u_p1 = new EncodedString(p1);
			EncodedString u_p2 = new EncodedString(p2);
			mdRightFielderUnmanaged.mdRightFielderSetReserved(i, u_p1.GetPtr(), u_p2.GetPtr());
		}

		public string GetReserved(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			return EncodedString.GetEncodedString(mdRightFielderUnmanaged.mdRightFielderGetReserved(i, u_p1.GetPtr()));
		}

		private class EncodedString : IDisposable {
			private IntPtr encodedString = IntPtr.Zero;
			private static Encoding encoding = Encoding.UTF8;

			public EncodedString(string str) {
				if (str == null)
					str = "";
				byte[] buffer = encoding.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				encodedString = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, encodedString, buffer.Length);
			}

			~EncodedString() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(encodedString);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetPtr() {
				return encodedString;
			}

			public static string GetEncodedString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return encoding.GetString(buffer);
			}
		}
	}
}
