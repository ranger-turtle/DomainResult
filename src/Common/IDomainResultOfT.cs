﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DomainResults.Common
{
	/// <summary>
	///		Represents the status id the domain operation along with returned value
	/// </summary>
	/// <typeparam name="T"> Value type of returned by the domain operation </typeparam>
	public interface IDomainResult<T> : IDomainResultBase
	{
		/// <summary>
		///		Value returned by the domain operation
		/// </summary>
		T Value { get; }

#if NETSTANDARD2_1 || NETCOREAPP3_0 || NETCOREAPP3_1
		// TODO: Consider to depricate the extension methods in this interface (below) and move them to 'IDomainResult'

		#region Extensions of 'IDomainResult<T>' [STATIC, PUBLIC] -------------

		/// <summary>
		///		Get 'success' status with a value. Later it can be converted to HTTP code 200 (Ok)
		/// </summary>
		/// <param name="value"> The value to be returned </param>
		static IDomainResult<T> Success(T value)						=> DomainResult<T>.Success(value);

		/// <summary>
		///		Get 'not found' status. Later it can be converted to HTTP code 404 (NotFound)
		/// </summary>
		/// <param name="message"> Optional message </param>
		static IDomainResult<T> NotFound(string? message = null)		=> DomainResult<T>.NotFound(message);
		/// <summary>
		///		Get 'not found' status. Later it can be converted to HTTP code 404 (NotFound)
		/// </summary>
		/// <param name="messages"> Custom messages </param>
		static IDomainResult<T> NotFound(IEnumerable<string> messages)	=> DomainResult<T>.NotFound(messages);

		/// <summary>
		///		Get 'error' status. Later it can be converted to HTTP code 400/422
		/// </summary>
		/// <param name="error"> Optional message </param>
		static IDomainResult<T> Error(string? error = null)				=> DomainResult<T>.Error(error);
		/// <summary>
		///		Get 'error' status. Later it can be converted to HTTP code 400/422
		/// </summary>
		/// <param name="errors"> Custom messages </param>
		static IDomainResult<T> Error(IEnumerable<string> errors)		=> DomainResult<T>.Error(errors);
		/// <summary>
		///		Get 'error' status with validation errors. Later it can be converted to HTTP code 400/422
		/// </summary>
		/// <param name="validationResults"> Results of a validation request </param>
		static IDomainResult<T> Error(IEnumerable<ValidationResult> validationResults) => DomainResult<T>.Error(validationResults);

		#endregion // Extensions of 'IDomainResult<T>' [STATIC, PUBLIC] -------

		#region Extensions of 'Task<IDomainResult<T>>' [STATIC, PUBLIC] -------

		/// <summary>
		///		Get 'success' status with a value (all wrapped in <see cref="Task{T}"/>).
		///		Later it can be converted to HTTP code 200 (Ok)
		/// </summary>
		/// <param name="value"> The value to be returned </param>
		static Task<IDomainResult<T>> SuccessTask(T value)						=> DomainResult<T>.SuccessTask(value);

		/// <summary>
		///		Get 'not found' status wrapped in a <see cref="Task{T}"/>. Later it can be converted to HTTP code 404 (NotFound)
		/// </summary>
		/// <param name="message"> Optional message </param>
		static Task<IDomainResult<T>> NotFoundTask(string? message = null)		=> DomainResult<T>.NotFoundTask(message);
		/// <summary>
		///		Get 'not found' status wrapped in a <see cref="Task{T}"/>. Later it can be converted to HTTP code 404 (NotFound)
		/// </summary>
		/// <param name="messages"> Custom messages </param>
		static Task<IDomainResult<T>> NotFoundTask(IEnumerable<string> messages)=> DomainResult<T>.NotFoundTask(messages);

		/// <summary>
		///		Get 'error' status wrapped in a <see cref="Task{T}"/>. Later it can be converted to HTTP code 400/422
		/// </summary>
		/// <param name="error"> Optional message </param>
		static Task<IDomainResult<T>> ErrorTask(string? error = null)			=> DomainResult<T>.ErrorTask(error);
		/// <summary>
		///		Get 'error' status wrapped in a <see cref="Task{T}"/>. Later it can be converted to HTTP code 400/422
		/// </summary>
		/// <param name="errors"> Custom messages </param>
		static Task<IDomainResult<T>> ErrorTask(IEnumerable<string> errors)		=> DomainResult<T>.ErrorTask(errors);
		/// <summary>
		///		Get 'error' status wrapped in a <see cref="Task{T}"/>. Later it can be converted to HTTP code 400/422
		/// </summary>
		/// <param name="validationResults"> Results of a validation request </param>
		static Task<IDomainResult<T>> ErrorTask(IEnumerable<ValidationResult> validationResults) => DomainResult<T>.ErrorTask(validationResults);
		
		#endregion // Extensions of 'Task<IDomainResult<T>>' [STATIC, PUBLIC] -
#endif
	}
}