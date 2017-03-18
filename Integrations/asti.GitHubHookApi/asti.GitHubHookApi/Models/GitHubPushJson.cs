using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace asti.GitHubHookApi.Models
{
   public class GitHubPushJson
   {
      [JsonProperty("ref")]
      public string Ref { get; set; }

      [JsonProperty("compare")]
      public string CompareUrl { get; set; }

      [JsonProperty("after")]
      public string AfterSha { get; set; }

      [JsonProperty("pusher")]
      public PullPusherJson Pusher { get; set; }

      [JsonProperty("commits")]
      public ICollection<PushCommitJson> Commits { get; set; }

      [JsonProperty("head_commit")]
      public PushHeadCommitJson HeadCommit { get; set; }

      [JsonProperty("repository")]
      public PullRepositoryJson Repository { get; set; }

      public string CommitsApiUrl()
      {
         return Repository != null ? Repository.CommitsUrl.Replace("{/sha}", $"/{AfterSha}") : string.Empty;
      }

      /// <summary>
      /// Represents the user who pushed the commit to a push JSON
      /// (all fields mapped)
      ///  https://developer.github.com/v3/activity/events/types/#pushevent
      /// </summary>
      public class PullPusherJson
      {
         /*
          "pusher": {
             "name": "baxterthehacker",
             "email": "baxterthehacker@users.noreply.github.com"
            },
          */
         [JsonProperty("name")]
         public string Name { get; set; }

         [JsonProperty("email")]
         public string Email { get; set; }
      }

      /*
       {
         "id": "0d1a26e67d8f5eaf1f6ba5c57fc3c7d91ac0fd1c",
         "tree_id": "f9d2a07e9488b91af2641b26b9407fe22a451433",
         "distinct": true,
         "message": "Update README.md",
         "timestamp": "2015-05-05T19:40:15-04:00",
         "url": "https://github.com/baxterthehacker/public-repo/commit/0d1a26e67d8f5eaf1f6ba5c57fc3c7d91ac0fd1c",
         "author": {
           "name": "baxterthehacker",
           "email": "baxterthehacker@users.noreply.github.com",
           "username": "baxterthehacker"
         },
         "committer": {
           "name": "baxterthehacker",
           "email": "baxterthehacker@users.noreply.github.com",
           "username": "baxterthehacker"
         },
         "added": [

         ],
         "removed": [

         ],
         "modified": [
           "README.md"
         ]
       }
       */

      /// <summary>
      /// Represents a commit form a Push event
      /// (not all fields represented here)
      /// https://developer.github.com/v3/activity/events/types/#pushevent
      /// </summary>
      public class PushCommitJson
      {
         [JsonProperty("id")]
         public string Id { get; set; }

         [JsonProperty("message")]
         public string CommitMessage { get; set; }

         [JsonProperty("timestamp")]
         public string TimeStampAsString { get; set; }

         [JsonProperty("url")]
         public string CommitUrl { get; set; }

         [JsonProperty("added")]
         public ICollection<string> Added { get; set; }

         [JsonProperty("removed")]
         public ICollection<string> Removed { get; set; }

         [JsonProperty("modified")]
         public ICollection<string> Modified { get; set; }
      }

      public class PushHeadCommitJson
      {
         /*
            "head_commit": {
             "id": "0d1a26e67d8f5eaf1f6ba5c57fc3c7d91ac0fd1c",
             "tree_id": "f9d2a07e9488b91af2641b26b9407fe22a451433",
             "distinct": true,
             "message": "Update README.md",
             "timestamp": "2015-05-05T19:40:15-04:00",
             "url": "https://github.com/baxterthehacker/public-repo/commit/0d1a26e67d8f5eaf1f6ba5c57fc3c7d91ac0fd1c",
             "author": {
               "name": "baxterthehacker",
               "email": "baxterthehacker@users.noreply.github.com",
               "username": "baxterthehacker"
             },
          */

         [JsonProperty("id")]
         public string Id { get; set; }

         [JsonProperty("distinct")]
         public bool Distinct { get; set; }

         [JsonProperty("message")]
         public string Message { get; set; }

         [JsonProperty("timestamp")]
         public string TimestampAsString { get; set; }

         [JsonProperty("url")]
         public string Url { get; set; }
      }

      public class PushHeadCommitAuthor : PullPusherJson
      {
         [JsonProperty("username")]
         public string UserName { get; set; }
      }

      /*
         "repository": {
       "id": 35129377,
       "name": "public-repo",
       "full_name": "baxterthehacker/public-repo",
       "owner": {
         "name": "baxterthehacker",
         "email": "baxterthehacker@users.noreply.github.com"
       },
       "private": false,
       "html_url": "https://github.com/baxterthehacker/public-repo",
       "description": "",
       "fork": false,
       "url": "https://github.com/baxterthehacker/public-repo",
       "forks_url": "https://api.github.com/repos/baxterthehacker/public-repo/forks",
       "keys_url": "https://api.github.com/repos/baxterthehacker/public-repo/keys{/key_id}",
       "collaborators_url": "https://api.github.com/repos/baxterthehacker/public-repo/collaborators{/collaborator}",
       "teams_url": "https://api.github.com/repos/baxterthehacker/public-repo/teams",
       "hooks_url": "https://api.github.com/repos/baxterthehacker/public-repo/hooks",
       "issue_events_url": "https://api.github.com/repos/baxterthehacker/public-repo/issues/events{/number}",
       "events_url": "https://api.github.com/repos/baxterthehacker/public-repo/events",
       "assignees_url": "https://api.github.com/repos/baxterthehacker/public-repo/assignees{/user}",
       "branches_url": "https://api.github.com/repos/baxterthehacker/public-repo/branches{/branch}",
       "tags_url": "https://api.github.com/repos/baxterthehacker/public-repo/tags",
       "blobs_url": "https://api.github.com/repos/baxterthehacker/public-repo/git/blobs{/sha}",
       "git_tags_url": "https://api.github.com/repos/baxterthehacker/public-repo/git/tags{/sha}",
       "git_refs_url": "https://api.github.com/repos/baxterthehacker/public-repo/git/refs{/sha}",
       "trees_url": "https://api.github.com/repos/baxterthehacker/public-repo/git/trees{/sha}",
       "statuses_url": "https://api.github.com/repos/baxterthehacker/public-repo/statuses/{sha}",
       "languages_url": "https://api.github.com/repos/baxterthehacker/public-repo/languages",
       "stargazers_url": "https://api.github.com/repos/baxterthehacker/public-repo/stargazers",
       "contributors_url": "https://api.github.com/repos/baxterthehacker/public-repo/contributors",
       "subscribers_url": "https://api.github.com/repos/baxterthehacker/public-repo/subscribers",
       "subscription_url": "https://api.github.com/repos/baxterthehacker/public-repo/subscription",
       "commits_url": "https://api.github.com/repos/baxterthehacker/public-repo/commits{/sha}",
       "git_commits_url": "https://api.github.com/repos/baxterthehacker/public-repo/git/commits{/sha}",
       "comments_url": "https://api.github.com/repos/baxterthehacker/public-repo/comments{/number}",
       "issue_comment_url": "https://api.github.com/repos/baxterthehacker/public-repo/issues/comments{/number}",
       "contents_url": "https://api.github.com/repos/baxterthehacker/public-repo/contents/{+path}",
       "compare_url": "https://api.github.com/repos/baxterthehacker/public-repo/compare/{base}...{head}",
       "merges_url": "https://api.github.com/repos/baxterthehacker/public-repo/merges",
       "archive_url": "https://api.github.com/repos/baxterthehacker/public-repo/{archive_format}{/ref}",
       "downloads_url": "https://api.github.com/repos/baxterthehacker/public-repo/downloads",
       "issues_url": "https://api.github.com/repos/baxterthehacker/public-repo/issues{/number}",
       "pulls_url": "https://api.github.com/repos/baxterthehacker/public-repo/pulls{/number}",
       "milestones_url": "https://api.github.com/repos/baxterthehacker/public-repo/milestones{/number}",
       "notifications_url": "https://api.github.com/repos/baxterthehacker/public-repo/notifications{?since,all,participating}",
       "labels_url": "https://api.github.com/repos/baxterthehacker/public-repo/labels{/name}",
       "releases_url": "https://api.github.com/repos/baxterthehacker/public-repo/releases{/id}",
       "created_at": 1430869212,
       "updated_at": "2015-05-05T23:40:12Z",
       "pushed_at": 1430869217,
       "git_url": "git://github.com/baxterthehacker/public-repo.git",
       "ssh_url": "git@github.com:baxterthehacker/public-repo.git",
       "clone_url": "https://github.com/baxterthehacker/public-repo.git",
       "svn_url": "https://github.com/baxterthehacker/public-repo",
       "homepage": null,
       "size": 0,
       "stargazers_count": 0,
       "watchers_count": 0,
       "language": null,
       "has_issues": true,
       "has_downloads": true,
       "has_wiki": true,
       "has_pages": true,
       "forks_count": 0,
       "mirror_url": null,
       "open_issues_count": 0,
       "forks": 0,
       "open_issues": 0,
       "watchers": 0,
       "default_branch": "master",
       "stargazers": 0,
       "master_branch": "master"
     },

       */
      public class PullRepositoryJson
      {
         [JsonProperty("html_url")]
         public string HtmlUrl { get; set; }

         [JsonProperty("url")]
         public string Url { get; set; }

         [JsonProperty("commits_url")]
         public string CommitsUrl { get; set; }
      }
   }

}
