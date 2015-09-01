// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//-----------------------------------------------------------------------
// </copyright>
// <summary>Tests for the ProjectTaskOutputPropertyInstanceTests class.</summary>
//-----------------------------------------------------------------------

using System.IO;
using System.Xml;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;

using NUnit.Framework;

namespace Microsoft.Build.UnitTests.OM.Instance
{
    /// <summary>
    /// Tests for the ProjectTaskOutputItemInstance class.
    /// </summary>
    [TestFixture]
    public class ProjectTaskOutputPropertyInstance_Tests
    {
        /// <summary>
        /// Test accessors
        /// </summary>
        [Test]
        public void Accessors()
        {
            var output = GetSampleTaskOutputInstance();

            Assert.AreEqual("p", output.TaskParameter);
            Assert.AreEqual("c", output.Condition);
            Assert.AreEqual("p1", output.PropertyName);
        }

        /// <summary>
        /// Create a ProjectTaskOutputPropertyInstance with some parameters
        /// </summary>
        private static ProjectTaskOutputPropertyInstance GetSampleTaskOutputInstance()
        {
            string content = @"
                    <Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003' >
                       <Target Name='t'>
                            <t1>
                                <Output TaskParameter='p' Condition='c' PropertyName='p1'/>
                            </t1>
                        </Target>
                    </Project>
                ";

            ProjectRootElement xml = ProjectRootElement.Create(XmlReader.Create(new StringReader(content)));
            Project project = new Project(xml);
            ProjectInstance instance = project.CreateProjectInstance();
            ProjectTaskInstance task = (ProjectTaskInstance)instance.Targets["t"].Children[0];
            ProjectTaskOutputPropertyInstance output = (ProjectTaskOutputPropertyInstance)task.Outputs[0];

            return output;
        }
    }
}
