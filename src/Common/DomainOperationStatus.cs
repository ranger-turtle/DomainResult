﻿namespace DomainResults.Common
{
	/// <summary>
	///		Status of the domain operation
	/// </summary>
	public enum DomainOperationStatus
	{
		/// <summary>
		///		Successful operation (gets converted to HTTP code 2xx on the API)
		/// </summary>
		Success,
		/// <summary>
		///		Entity not found (gets converted to HTTP code 404 on the API)
		/// </summary>
		NotFound,
		/// <summary>
		///		Failed operation (gets converted to HTTP code 4xx on the API)
		/// </summary>
		Failed,
		/// <summary>
		///		Refused to authorize the operation (gets converted to HTTP code 403 on the API)
		/// </summary>
		Unauthorized,
	}
}
