app.config(['$httpProvider', function ($httpProvider) {

    $httpProvider.interceptors.push('HttpInterceptor');
}]);

app.factory('HttpInterceptor', ['$q', '$location', '$rootScope', function ($q, $location, $rootScope) {
    return {
        responseError: function (rejection) {
            if (rejection.status === 404) {
                
                $location.path('/404');
            }
            if (rejection.status === 500) {
                $rootScope.errorHttp = {
                    code: rejection.status,
                    title: rejection.statusText,
                    service: rejection.config.url
                }
                console.log(rejection.data);
                $location.path('/500');
            }
            return $q.reject(rejection);
        }
    };
}]);