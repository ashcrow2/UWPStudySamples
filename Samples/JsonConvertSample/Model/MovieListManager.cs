using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JsonConvertSample.Model
{
    public class MovieListManager
    {
        public async Task<GettingStarted> GetFromString()
        {
            //要访问网页的api，肯定要一个httpClient
            HttpClient http = new HttpClient();

            //通过get请求，异步获取的方式，获得响应的值
            HttpResponseMessage response = await http.GetAsync("http://v3.wufazhuce.com:8000/api/music/bymonth/2017-11-13%2000:00:00?channel=wdj&version=4.0.2&uuid=ffffffff-a90e-706a-63f7-ccf973aae5ee&platform=android");

            //同样是通过异步的方式，从响应的内容中，序列化到字符串的形式，到这里我们就获得了api那里拿来的json数据了。
            string resultJson = await response.Content.ReadAsStringAsync();


            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.NullValueHandling = NullValueHandling.Include;
          
            GettingStarted result=JsonConvert.DeserializeObject<GettingStarted>(resultJson,settings);


            return result;


        }

        public void GetToString()
        {
            GettingStarted object1 = new GettingStarted();
            object1.Data = new List<Datum>();
            object1.Data.Add(new Datum() { Album="666"});


            String result = JsonConvert.SerializeObject(object1);

        }

    }

    public class GettingStarted
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("res")]
        public long Res { get; set; }
    }

    public class Datum
    {
        [JsonProperty("album")]
        public string Album { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("author_list")]
        public List<Author> AuthorList { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("music_id")]
        public string MusicId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("start_video")]
        public string StartVideo { get; set; }

        [JsonProperty("story_title")]
        public string StoryTitle { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class Author
    {
        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("fans_total")]
        public string FansTotal { get; set; }

        [JsonProperty("is_settled")]
        public string IsSettled { get; set; }

        [JsonProperty("settled_type")]
        public string SettledType { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("wb_name")]
        public string WbName { get; set; }

        [JsonProperty("web_url")]
        public string WebUrl { get; set; }
    }

}
