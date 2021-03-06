﻿**Does this website use cookies or collect data?** <br/>
No, <u>this website has no cookies and doesn't collect data.</u>

**Why?** <br/>
Cookies and analytics are great and highly recommended for improving the usability of a website. However, it takes time to implement features, and time hasn't been spent in this area.

**So this website might have cookies and data collection later?** <br/>
Sure, for remembering state, and collecting usage and bug reports to improve the website. But it's currently not a priority.

**Can cookies and data collection be added faster?** <br/>
This project is open-sourced, so if there is a feature that you believe should be added to this website, you could create a fork for that feature and add some work to it, and that may get the feature in sooner.

**Which would be more useful, cookies or data collection?** <br/>
Cookies would be, so you don't lose your state if you refresh the page. I am not sure this website is complicated enough and has enough development to warrant analytics. Suppose data collection could show if non-English speakers are using this website so that localizations could be considered. But, it's not like good translations are free, or without maintenance costs. So even if the data revealed something, the web development of this website may not act on it.

**So is this website doing anything illegal, or will it be doing anything illegal?** <br/>
What? No. This website is not doing anything illegal, and won't be doing anything illegal: no data selling, or things of that nature. IANAL, but I believe a third-party tool like this is fine.

**Okay.** <br/>
Cool.

**So if data collection is added, how would that be done?** <br/>
This website would use a third-party analytics provider, probably Google Analytics. Data from events on the website would go to GA, and the data would appear on GA's dashboard. Data like what calculator settings are being used, what pages are being visited, and other data GA collects by default, like country of origin.

**I am not sure I am happy with that. Aren't cookies and data collection terrible for privacy?** <br/>
Anything can be used poorly. I'll add an option to opt-in to that if we get there. Probably via a cookie, that will save if the current browser state is opt-in to data collection and/or cookies. That means having to opt-in whenever the state is lost. Which kind of defeats the purpose of analytics? A popup or banner could be annoying to request the opt-in, so a toggle option would probably be added to this page. *So to restate, this toggle would have amnesia and would eventually forget the opt-in, automatically opting you out.* Actually... rechecking this page to look at a toggle sounds tedious, so perhaps this privacy toggle will also appear somewhere non intrusively on the UI for people that do want to opt-in with one click. Or I should say two clicks, one to toggle cookies, and then one to then toggle analytics.

**Okay, so like those optional "sharing data" checkboxes *that start as unchecked.* I am happy with that.** <br/>
Glad to hear.

**Browsing the website some more, the roadmap mentions "Online Profile. Create an account and save hideout floor setups." If that is implemented, how are you going to make that GDPR compliant?**<br />
For that, I would use a third-party identity and data solution, probably brainCloud. A login/signup and profile page would be added. You would be able to export and delete your data, such as save files and the account itself. And that would be everything needed for reasonable compliance. But a feature like that would come way later, and would only be justified when sophisticated hideout design features are added to the website. 

**What if I forget I made an account on this website, or become incapacitated to the point that I can't delete my account?**<br />
Suppose the system will also delete accounts that have become inactive. I am not a fan of the concept of automatic deletions, from a bad experience of an account being automatically deleted. But, as long as people aren't surprised by it, and can easily re-create their account by importing their personally saved copies of that data, it sounds like it could be great implementation. 

**As a thought experiment, instead of using third-party tools, why don't you store all the cookie, analytics, and profile data on the website with no session memory? Allow people to export and import that data from their machine each time they visit and leave the site, so all data is stored on the computer of the current user. The website maintainer can't see the data and make decisions on it, and it would be buggier and harder to test internally. But still, it's not like this website provides a valuable service or is monetized directly.**<br />
That's a very cool idea. I could delete this privacy policy page, and add instructions on how to export and import the data between sessions.


<br/><br/>