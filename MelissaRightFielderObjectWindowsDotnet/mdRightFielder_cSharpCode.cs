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
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderCreate();
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderDestroy(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderSetLicenseString(IntPtr i, string p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetPathToRightFielderFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetPathToRightFielderFiles(IntPtr i, string p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetBuildNumber(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetDatabaseDate(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetLicenseExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetLicenseExpirationDate(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderInitializeDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderInitializeDataFiles(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetInitializeErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetInitializeErrorString(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetDelimiter", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetDelimiter(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetAcceptFullName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptFullName(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetAcceptDepartment", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptDepartment(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetAcceptCompany", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptCompany(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetAcceptAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptAddress(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetAcceptCityStateZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptCityStateZip(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetAcceptCountry", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptCountry(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetAcceptPhone", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptPhone(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetAcceptEmail", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptEmail(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetAcceptURL", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetAcceptURL(IntPtr i, Int32 p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetUserPattern", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderSetUserPattern(IntPtr i, string p1, string p2);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderParse", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderParse(IntPtr i, string p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderParseFreeForm", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderParseFreeForm(IntPtr i, string p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderParseFielded", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderParseFielded(IntPtr i, string p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetFullName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetFullName(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetFullNameNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetFullNameNext(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetDepartment", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetDepartment(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetDepartmentNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetDepartmentNext(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetCompany", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetCompany(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetCompanyNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetCompanyNext(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetAddress(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetAddress2", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetAddress2(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetAddress3", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetAddress3(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetCity", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetCity(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetState", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetState(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetPostalCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetPostalCode(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetCountry", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetCountry(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetLastLine", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetLastLine(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetPhone", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetPhone(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetPhoneNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetPhoneNext(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetPhoneType", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetPhoneType(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetPhoneTypeNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetPhoneTypeNext(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetEmail", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetEmail(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetEmailNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetEmailNext(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetURL", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetURL(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetURLNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetURLNext(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetUserField", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetUserField(IntPtr i, string p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetUserFieldNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetUserFieldNext(IntPtr i, string p1);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetUnrecognized", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetUnrecognized(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetUnrecognizedNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdRightFielderGetUnrecognizedNext(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetResults", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetResults(IntPtr i);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetResultCodeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetResultCodeDescription(IntPtr i, string resultCode, Int32 opt);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderSetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdRightFielderSetReserved(IntPtr i, string p1, string p2);
			[DllImport("mdRightFielder.dll", EntryPoint = "mdRightFielderGetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdRightFielderGetReserved(IntPtr i, string p1);
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
			return (mdRightFielderUnmanaged.mdRightFielderSetLicenseString(i, p1) != 0);
		}

		public void SetPathToRightFielderFiles(string p1) {
			mdRightFielderUnmanaged.mdRightFielderSetPathToRightFielderFiles(i, p1);
		}

		public string GetBuildNumber() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetBuildNumber(i));
		}

		public string GetDatabaseDate() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetDatabaseDate(i));
		}

		public string GetLicenseExpirationDate() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetLicenseExpirationDate(i));
		}

		public ProgramStatus InitializeDataFiles() {
			return (ProgramStatus)mdRightFielderUnmanaged.mdRightFielderInitializeDataFiles(i);
		}

		public string GetInitializeErrorString() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetInitializeErrorString(i));
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
			return (mdRightFielderUnmanaged.mdRightFielderSetUserPattern(i, p1, p2) != 0);
		}

		public bool Parse(string p1) {
			return (mdRightFielderUnmanaged.mdRightFielderParse(i, p1) != 0);
		}

		public bool ParseFreeForm(string p1) {
			return (mdRightFielderUnmanaged.mdRightFielderParseFreeForm(i, p1) != 0);
		}

		public bool ParseFielded(string p1) {
			return (mdRightFielderUnmanaged.mdRightFielderParseFielded(i, p1) != 0);
		}

		public string GetFullName() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetFullName(i));
		}

		public bool GetFullNameNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetFullNameNext(i) != 0);
		}

		public string GetDepartment() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetDepartment(i));
		}

		public bool GetDepartmentNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetDepartmentNext(i) != 0);
		}

		public string GetCompany() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetCompany(i));
		}

		public bool GetCompanyNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetCompanyNext(i) != 0);
		}

		public string GetAddress() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetAddress(i));
		}

		public string GetAddress2() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetAddress2(i));
		}

		public string GetAddress3() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetAddress3(i));
		}

		public string GetCity() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetCity(i));
		}

		public string GetState() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetState(i));
		}

		public string GetPostalCode() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetPostalCode(i));
		}

		public string GetCountry() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetCountry(i));
		}

		public string GetLastLine() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetLastLine(i));
		}

		public string GetPhone() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetPhone(i));
		}

		public bool GetPhoneNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetPhoneNext(i) != 0);
		}

		public string GetPhoneType() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetPhoneType(i));
		}

		public bool GetPhoneTypeNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetPhoneTypeNext(i) != 0);
		}

		public string GetEmail() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetEmail(i));
		}

		public bool GetEmailNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetEmailNext(i) != 0);
		}

		public string GetURL() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetURL(i));
		}

		public bool GetURLNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetURLNext(i) != 0);
		}

		public string GetUserField(string p1) {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetUserField(i, p1));
		}

		public bool GetUserFieldNext(string p1) {
			return (mdRightFielderUnmanaged.mdRightFielderGetUserFieldNext(i, p1) != 0);
		}

		public string GetUnrecognized() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetUnrecognized(i));
		}

		public bool GetUnrecognizedNext() {
			return (mdRightFielderUnmanaged.mdRightFielderGetUnrecognizedNext(i) != 0);
		}

		public string GetResults() {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetResults(i));
		}

		public string GetResultCodeDescription(string resultCode, ResultCdDescOpt opt) {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetResultCodeDescription(i, resultCode, (int)opt));
		}

		public string GetResultCodeDescription(string resultCode) {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetResultCodeDescription(i, resultCode, (int)ResultCdDescOpt.ResultCodeDescriptionLong));
		}

		public void SetReserved(string p1, string p2) {
			mdRightFielderUnmanaged.mdRightFielderSetReserved(i, p1, p2);
		}

		public string GetReserved(string p1) {
			return Marshal.PtrToStringAnsi(mdRightFielderUnmanaged.mdRightFielderGetReserved(i, p1));
		}

		private class Utf8String : IDisposable {
			private IntPtr utf8String = IntPtr.Zero;

			public Utf8String(string str) {
				if (str == null)
					str = "";
				byte[] buffer = Encoding.UTF8.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				utf8String = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, utf8String, buffer.Length);
			}

			~Utf8String() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(utf8String);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetUtf8Ptr() {
				return utf8String;
			}

			public static string GetUnicodeString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return Encoding.UTF8.GetString(buffer);
			}
		}
	}
}
