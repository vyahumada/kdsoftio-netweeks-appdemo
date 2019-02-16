(function () {
    'use strict';

    angular.module('demoApp').service('CategoriasService', ['$http', function ($http) {
        var service = this;
        var baseUrl = '/api/Categorias';

        service.obtenerTodos = () => {
            return $http.get(baseUrl + '/ObtenerCategorias');
        };

        service.obtenerXid = (id) => {
            return $http.get(baseUrl + '/ObtenerCategoriaXid/' + id);
        };
        
        service.crear = (categoria) => {
            var options = {
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json'
                }
            };

            return $http.post(baseUrl, categoria, options);
        };

        service.modificar = (id, categoria) => {
            var options = {
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json'
                }
            };

            return $http.put(baseUrl + '/' + id, categoria, options);
        };

        service.eliminar = (id) => {
            return $http.delete(baseUrl + '?id=' + id);
        };
    }]);
})();