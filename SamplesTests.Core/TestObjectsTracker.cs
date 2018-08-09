using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmitMapperTests;
using Xunit;

namespace LightDataAccess
{
	
	public class TestObjectsTracker
	{
		public class A
		{
			public string f1 = "f1";
			public int f2 = 2;
			public bool f3 = true;
		}

		[Fact]
		public void TestObjectsTracking()
		{
			var tracker = new ObjectsChangeTracker();
			var a = new A();
			tracker.RegisterObject(a);
			a.f2 = 3;
			var changes = tracker.GetChanges(a);
			Assert.True( changes[0].name == "f2");
			tracker.RegisterObject(a);
			changes = tracker.GetChanges(a);
			Assert.True(changes.Length == 0);

			a.f1 = "new";
			a.f2 = 13;
			a.f3 = false;
			for (int i = 0; i < 10; ++i)
			{
				tracker.GetChanges(a);
			}

			changes = tracker.GetChanges(a);
            
			Assert.True(TestUtils.AreEqualArraysUnordered(new[] { "f1", "f2", "f3" }, changes.Select(c => c.name).ToArray()));

			changes = tracker.GetChanges(new A());
			Assert.Null(changes);
		}
	}
}
