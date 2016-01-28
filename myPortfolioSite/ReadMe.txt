This is a ReadMe for GitHub/source notes.

-Setup

The goal is to be able to clone this, add some minor configuration, and deploy it as an ASP.Net website.
As an example, to deploy/publish, I'm using Web Deploy, but the publish profiles aren't added to the project.
As another example, SMTP is used for contact form, but my current personal settings are not part of the project.
...this is the kind of configuration that is expected, otherwise it should all work and everything.

While using Web Deploy shouldn't be a requirement, it is expected, and things like Web.config transforms are used,
though not really as there is little difference between the two.
(Note! Currently, the transforms only get used on packaging/publishing)