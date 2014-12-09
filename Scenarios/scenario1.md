# Scenario #1: api.rarebeers.com
This scenario describes an api that implements a backend for a basic webshop concept to sell rare beers. 

Through this scenario we attempt to outline various ways in which hypermedia could be added to resources, based on a realistic use-case. At the same time, formatting the envisioned responses based on different formats, will reveal overlap and distinctive features of each specification, guiding us towards the most flexible implementation of DotNetHypermedia.

Through the API, a user can:

* Browse breweries
* See the details of a single brewery
* Browse beers
* See details of a single beer
* Place a beer in his shopping basket

The API should offer:

* Recommended beers based on co-purchases. ("People who bought X also bought Y and Z.") 

## Assumptions
* The API is authenticated on a per user base.
* We want to return paged results with a page size of 5 items. 
* Actual checkout and payment are out of scope.
* We sell beers from 10 breweries ("Brewery A"  ... "Brewery J") each of which sells 3 different beers ("Beer A1" .. "Beer A3").
* Recommendations are user-specific and freshly retrieved, per request, from an external service (not persisted inside our API).

## API
The api exposes the following resources:

* `/breweries?page=xxx` - A paged listing of all breweries that we sell beers of (`GET`);
* `/breweries/xxx` - A representing a single brewery (`GET`);
* `/beers?brewery_id=xxx&page=xxx` - A paged listing of all beers, optionally filtered by the id of the brewery (`GET`);
* `/beers/xxx` - A representation of a single beer (`GET`);
* `/basket` - A user specific listing of all beers the user wants to purchase (`PUT` and `GET`);

**Note**: The checkout process is not in scope for this example

## Domain
The domain model backing this api could look something like this:

```
Brewery
* Id
* Name
* Address      // Single field for simplicity sake
* Beers[]      // References

Beer
* Id
* Brewery      // Reference
* Name
* Vol          // Alcohol percentage
* Price

BasketItem
* Beer        // Reference
* Quantity
```

## Format specific implementations
The following is a list of possible implementations of the described scenario in specific formats:

* [application/hal+json](scenario1-hal.md)
* TODO: Add more formats here for complete comparison
