(function () {
    'use strict';

    angular.module('demoApp').service('LibrosService', ['$http', function ($http) {
        var service = this;
        var baseUrl = '/api/Libros';

        service.obtenerTodos = () => {
            return $http.get(baseUrl + '/ObtenerLibros');
        };

        service.obtenerXid = (id) => {
            return $http.get(baseUrl + '/ObtenerLibroxId/' + id);
        };
        
        service.crear = (libro) => {
            var options = {
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json'
                }
            };

            return $http.post(baseUrl, libro, options);
        };

        service.modificar = (id, libro) => {
            var options = {
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json'
                }
            };

            return $http.put(baseUrl + '/' + id, libro, options);
        };

        service.eliminar = (id) => {
            return $http.delete(baseUrl + '/' + id);
        };
    }]);
})();