﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.Tests;

public class JavaConfluentAppTest : BaseE2E, IClassFixture<JavaConfluentE2EFixture>
{
	private readonly ITestOutputHelper _output;

	public JavaConfluentAppTest(ITestOutputHelper output) : base(Language.JAVA, BrokerType.CONFLUENT, output)
	{
		_output = output;
	}

	[Fact]
	public async Task Java_App_Test_Single_Event_Confluent()
	{
		//Generate Random Guids
		var reqMsgs = Utils.GenerateRandomMsgs(AppType.SINGLE_EVENT);

		//Create HttpRequestEntity with url and query parameters
		var httpRequestEntity = Utils.GenerateTestHttpRequestEntity(Constants.JAVAAPP_CONFLUENT_PORT,
			Constants.JAVA_SINGLE_APP_NAME, reqMsgs);

		//Test e2e flow with trigger httpRequestEntity and expectedOutcome
		await Test(AppType.SINGLE_EVENT, InvokeType.HTTP, httpRequestEntity, null, reqMsgs);
	}

	[Fact]
	public async Task Java_App_Test_Multi_Event_Confluent()
	{
		//Generate Random Guids
		var reqMsgs = Utils.GenerateRandomMsgs(AppType.BATCH_EVENT);

		//Create HttpRequestEntity with url and query parameters
		var httpRequestEntity =
			Utils.GenerateTestHttpRequestEntity(Constants.JAVAAPP_CONFLUENT_PORT, Constants.JAVA_MULTI_APP_NAME,
				reqMsgs);

		//Test e2e flow with trigger httpRequestEntity and expectedOutcome
		await Test(AppType.BATCH_EVENT, InvokeType.HTTP, httpRequestEntity, null, reqMsgs);
	}
}