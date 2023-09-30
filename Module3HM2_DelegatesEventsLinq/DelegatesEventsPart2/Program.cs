using DelegatesEventsPart2;
using DelegatesEventsPart2.Subscribers;

PostOffice postOffice = new PostOffice();

Person person = new Person();
person.SubscribeEmail(postOffice);

School school = new School();
school.SubscribeEmail(postOffice);
school.SubscribeNotification(postOffice);

postOffice.AddEmail("email");
postOffice.AddPackage("package");
postOffice.AddNotification("notification");

school.UnsubscribeEmail(postOffice);

postOffice.AddEmail("emailemailemail");
