using Nop.Core.Domain.Forums;
using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Forums
{
    [TestFixture]
    public class ForumSubscriptionPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_forum_subscription_forum_subscribed()
        {
            var customer = TestsData.GetCustomer();
            var customerFromDb = SaveAndLoadEntity(customer);
            customerFromDb.ShouldNotBeNull();

            var forumGroup = TestsData.GetForumGroup;

            var forumGroupFromDb = SaveAndLoadEntity(forumGroup);
            forumGroupFromDb.ShouldNotBeNull();
            forumGroupFromDb.Name.ShouldEqual("Forum Group 1");
            forumGroupFromDb.DisplayOrder.ShouldEqual(1);

            var forum = TestsData.GetForum(forumGroupFromDb);

            forumGroup.Forums.Add(forum);
            var forumFromDb = SaveAndLoadEntity(forum);
            forumFromDb.ShouldNotBeNull();
            forumFromDb.Name.ShouldEqual("Forum 1");
            forumFromDb.Description.ShouldEqual("Forum 1 Description");
            forumFromDb.DisplayOrder.ShouldEqual(10);
            forumFromDb.NumTopics.ShouldEqual(15);
            forumFromDb.NumPosts.ShouldEqual(25);
            forumFromDb.ForumGroupId.ShouldEqual(forumGroupFromDb.Id);

            var forumTopic = TestsData.GetForumTopic(customerFromDb, forumFromDb);

            var forumTopicFromDb = SaveAndLoadEntity(forumTopic);
            forumTopicFromDb.ShouldNotBeNull();
            forumTopicFromDb.Subject.ShouldEqual("Forum Topic 1");
            forumTopicFromDb.Views.ShouldEqual(123);
            forumTopicFromDb.NumPosts.ShouldEqual(100);
            forumTopicFromDb.TopicTypeId.ShouldEqual((int)ForumTopicType.Sticky);
            forumTopicFromDb.ForumId.ShouldEqual(forumFromDb.Id);

            var forumSubscription = TestsData.GetForumSubscription(customerFromDb, forumFromDb);

            var forumSubscriptionFromDb = SaveAndLoadEntity(forumSubscription);
            forumSubscriptionFromDb.ShouldNotBeNull();
            forumSubscriptionFromDb.SubscriptionGuid.ToString().ShouldEqual("11111111-2222-3333-4444-555555555555");
            forumSubscriptionFromDb.TopicId.ShouldEqual(0);
            forumSubscriptionFromDb.ForumId.ShouldEqual(forumFromDb.Id);
        }

        [Test]
        public void Can_save_and_load_forum_subscription_topic_subscribed()
        {
            var customer = TestsData.GetCustomer();
            var customerFromDb = SaveAndLoadEntity(customer);
            customerFromDb.ShouldNotBeNull();

            var forumGroup = TestsData.GetForumGroup;

            var forumGroupFromDb = SaveAndLoadEntity(forumGroup);
            forumGroupFromDb.ShouldNotBeNull();
            forumGroupFromDb.Name.ShouldEqual("Forum Group 1");
            forumGroupFromDb.DisplayOrder.ShouldEqual(1);

            var forum = TestsData.GetForum(forumGroupFromDb);

            forumGroup.Forums.Add(forum);
            var forumFromDb = SaveAndLoadEntity(forum);
            forumFromDb.ShouldNotBeNull();
            forumFromDb.Name.ShouldEqual("Forum 1");
            forumFromDb.Description.ShouldEqual("Forum 1 Description");
            forumFromDb.DisplayOrder.ShouldEqual(10);
            forumFromDb.NumTopics.ShouldEqual(15);
            forumFromDb.NumPosts.ShouldEqual(25);
            forumFromDb.ForumGroupId.ShouldEqual(forumGroupFromDb.Id);

            var forumTopic = TestsData.GetForumTopic(customerFromDb, forumFromDb);

            var forumTopicFromDb = SaveAndLoadEntity(forumTopic);
            forumTopicFromDb.ShouldNotBeNull();
            forumTopicFromDb.Subject.ShouldEqual("Forum Topic 1");
            forumTopicFromDb.Views.ShouldEqual(123);
            forumTopicFromDb.NumPosts.ShouldEqual(100);
            forumTopicFromDb.TopicTypeId.ShouldEqual((int)ForumTopicType.Sticky);
            forumTopicFromDb.ForumId.ShouldEqual(forumFromDb.Id);

            var forumSubscription = TestsData.GetForumSubscription(customerFromDb);
            forumSubscription.TopicId = forumTopicFromDb.Id;

            var forumSubscriptionFromDb = SaveAndLoadEntity(forumSubscription);
            forumSubscriptionFromDb.ShouldNotBeNull();
            forumSubscriptionFromDb.SubscriptionGuid.ToString().ShouldEqual("11111111-2222-3333-4444-555555555555");
            forumSubscriptionFromDb.TopicId.ShouldEqual(forumTopicFromDb.Id);
            forumSubscriptionFromDb.ForumId.ShouldEqual(0);
        }
    }
}
