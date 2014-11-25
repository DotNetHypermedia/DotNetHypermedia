# Scenario #1: HAL
See [this page](scenario1.md) for a detailed description of the implemented scenario.

## GET /breweries?page=2
```
{
	"_links" : {
		"curies" : [{
			"name" : "rb",
			"href" : "https://docs.rarebeers.com/{rel}",
			"templated" : true
		}],
		"self" : { "href" : "/breweries?page=2"},
		"rb:brewery" : [
			{ "href" : "/breweries/6" }, 
			{ "href" : "/breweries/7" },
			{ "href" : "/breweries/8" }, 
			{ "href" : "/breweries/9" },
			{ "href" : "/breweries/10" }
		],
		"last" : { "href" : "/breweries?page=2"},			
		"first" : { "href" : "/breweries?page=1"},
		"prev" : { "href" : "/breweries?page=1"}	
	}
	"_embedded" : {
		"rb:brewery" : [
			{
				"_links" : {
					"self" : { "href" : "/breweries/6"},
					"rb:beers-brewed" : { "href" : "/beers?brewery=6"}				
				},
				"name" : "Brewery F"
			},
			{
				"_links" : {
					"self" : { "href" : "/breweries/7"},
					"rb:beers-brewed" : { "href" : "/beers?brewery=7"}				
				},
				"name" : "Brewery G"
			},
			{
				"_links" : {
					"self" : { "href" : "/breweries/8"},
					"rb:beers-brewed" : { "href" : "/beers?brewery=8"}				
				},
				"name" : "Brewery H"
			},
			{
				"_links" : {
					"self" : { "href" : "/breweries/9"},
					"rb:beers-brewed" : { "href" : "/beers?brewery=9"}				
				},
				"name" : "Brewery I"
			},
			{
				"_links" : {
					"self" : { "href" : "/breweries/10"},
					"rb:beers-brewed" : { "href" : "/beers?brewery=10"}				
				},
				"name" : "Brewery J"
			}
		]
	},
	"page" : 2,
	"page-count" : 2
}
```
Note how we use both [CURIES](http://www.w3.org/TR/2010/NOTE-curie-20101216/) and [IANA](http://www.iana.org/assignments/link-relations/link-relations.xhtml) link relations. Officially the IANA link relations are not specified in the [spec](https://tools.ietf.org/html/draft-kelly-json-hal-06) but it is good practice to use well-known relations for better discoverability. We could have also used  URI's directly but opted for CURIES for brevity.

Also note how we apply the [Hypermedia Cache Pattern](https://tools.ietf.org/html/draft-kelly-json-hal-06#section-8.3) to avoid unnecessary subsequent requests for individual breweries. Of interest is the fact that the representation of an embedded resource does not necessarily follows that of the full resource (compare with the representation from the next section).

## GET /breweries/6
```
{
	"_links" : {
		"curies" : [{
			"name" : "rb",
			"href" : "https://docs.rarebeers.com/{rel}",
			"templated" : true
		}],	
		"self" : { "href" : "/breweries/6"},
		"rb:beer" : [
			{ "href" : "/beers/60"},
			{ "href" : "/beers/61"},
			{ "href" : "/beers/62"}
		]
	},
	"_embedded" : {
		"rb:beer" : [
			{
				"_links" : {
					"self" : { "href" : "/beers/60"}				
				},			
				"name" : "Beer F1"
			},
			{
				"_links" : {
					"self" : { "href" : "/beers/61"}				
				},			
				"name" : "Beer F2"
			},
			{
				"_links" : {
					"self" : { "href" : "/beers/62"}				
				},			
				"name" : "Beer F3"
			}
		]	
	},
	"id" : 6, 
	"name" : "Brewery F",
	"address" : "Heinekenplein 1, 1234 AB, Amsterdam, The Netherlands"
}
```
## GET /beers?brewery=6
```
{
	"_links" : {
		"curies" : [{
			"name" : "rb",
			"href" : "https://docs.rarebeers.com/{rel}",
			"templated" : true
		}],
		"self" : { "href" : "/beers?brewery=6"},
		"rb:beers" : { "href" : "/beers"},
		"rb:beer" : [
			{ "href" : "/beers/60"},
			{ "href" : "/beers/61"},
			{ "href" : "/beers/62"}
		],
		"last" : { "href" : "/beers?brewery&page=1"},			
		"first" : { "href" : "/beers?brewery=6&page=1"}
	}
	"_embedded" : {
		"rb:beer" : [
			{
				"_links" : {
					"self" : { "href" : "/beers/60"}				
				},			
				"name" : "Beer F1"
			},
			{
				"_links" : {
					"self" : { "href" : "/beers/61"}				
				},			
				"name" : "Beer F2"
			},
			{
				"_links" : {
					"self" : { "href" : "/beers/62"}				
				},			
				"name" : "Beer F3"
			}
		]	
	},
	"page" : 1,
	"page-count" : 1
}
```

Note that, as a brewery only brews 3 beers, there are no navigational, paging related links. If there would not be a filter for brewery with id 6, we would of course get the appropriate links.

## GET /beers/60
```
{
	"_links" : {
		"curies" : [{
			"name" : "rb",
			"href" : "https://docs.rarebeers.com/{rel}",
			"templated" : true
		}],
		"self" : { "href" : "/beers/60"},
		"rb:brewery" : { "href" : "/breweries/6"},
		"rd:recommendation" : [
			{ "href" : "/beers/12"},
			{ "href" : "/beers/50"},
			{ "href" : "/beers/101"}
		]				
	},
	"_embedded" : {
		"rb:brewery" : {
			"_links" : {
				"self" : { "href" : "/breweries/6"},
				"rb:beers-brewed" : { "href" : "/beers?brewery=6"}				
			},
			"name" : "Brewery F"
		},
		"rb:recommendation" : [
			{
				"_links" : {
					"self" : { "href" : "/beers/12"}				
				},			
				"name" : "Beer A3"
			},
			{
				"_links" : {
					"self" : { "href" : "/beers/50"}				
				},			
				"name" : "Beer E1"
			},
			{
				"_links" : {
					"self" : { "href" : "/beers/101"}				
				},			
				"name" : "Beer J2"
			}
		]
	}
	"id" : 60,			
	"name" : "Beer F1",
	"vol" : 3.5,
	"price" : 2.99
}
```
## GET or PUT /basket
```
{
	"_links" : {
		"curies" : [{
			"name" : "rb",
			"href" : "https://docs.rarebeers.com/{rel}",
			"templated" : true
		}],
		"self" : { "href" : "/basket"},
		"rd:beer-in-basket" : [
			{ "href" : "/beers/20"},
			{ "href" : "/beers/42"}
		]				
	},
	"_embedded" : {
		"rb:brewery" : {
			"_links" : {
				"self" : { "href" : "/breweries/6"},
				"rb:beers-brewed" : { "href" : "/beers?brewery=6"}				
			},
			"name" : "Brewery F"
		},
		"rb:beer-in-basket" : [
			{
				"_links" : {
					"self" : { "href" : "/beers/20"}	
				},			
				"name" : "Beer C1",
				"price" : 6.00,
				"quantity" : 2,
				"total" : 12.00,
				"added" : "2014-11-25T16:07:43 +01:00"
			},
			{
				"_links" : {
					"self" : { "href" : "/beers/42"}	
				},			
				"name" : "Beer D3",
				"price" : 1.95,
				"quantity" : 1,
				"total" : 1.95,
				"added" : "2014-11-25T16:07:43 +01:00"
			}
		]
	},
	"total" : 13.95
}
```