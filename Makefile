PROJECT_NAME ?= GoodFilms

.PHONY: migrations db hello

migrations:
	cd ./GoodFilms.Data && dotnet -ef --startup-project ../GoodFilms.Web/ migrations add Initial && cd..

db:
	cd /.GoodFilms.Data && dotnet -ef --startup-project	../GoodFilms.Web/ database-update && cd ..

hello:

	echo 'hello'