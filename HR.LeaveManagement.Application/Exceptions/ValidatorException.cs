﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions
{
	public class ValidatorException : ApplicationException
	{
		public List<string> Errors { get; set; } = new List<string>();

		public ValidatorException(ValidationResult validationResult)
		{
			foreach (var error in validationResult.Errors)
			{
				Errors.Add(error.ErrorMessage);
			}
		}
	}
}
