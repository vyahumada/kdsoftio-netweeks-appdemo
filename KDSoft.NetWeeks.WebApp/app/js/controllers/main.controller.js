(function () {
    'use strict';

    angular.module('demoApp').controller('MainController', ['LibrosService', 'CategoriasService', function (LibrosService, CategoriasService) {
        var ctrl = this;
        
        ctrl.acciones = {
          crear: { id: 1, titulo: 'Nuevo', boton: 'Guardar', editable: true },
          modificar: { id: 2, titulo: 'Modificar', boton: 'Guardar', editable: true },
          eliminar: { id: 3, titulo: 'Eliminar', boton: 'Eliminar', editable: false }
        };

        ctrl.limpiarLibro = () => {
          ctrl.libro = {
            nombre: null,
            fechaEdicion: null,
            edicion: null,
            enStock: false,
            id_Categoria: null
          };
        };

        ctrl.obtenerLibros = () => {
            LibrosService.obtenerTodos().then(libros => {
                ctrl.libros = libros.data;
            });
        };

        ctrl.obtenerCategorias = () => {
          CategoriasService.obtenerTodos().then(categorias => {
            ctrl.categorias = categorias.data;
          });
        };

        ctrl.agregarCategoria = (nombre) => {
          if(!ctrl.nuevaCategoria) {
            return;
          }

          CategoriasService.crear({ nombre: nombre }).then(() => {
            ctrl.nuevaCategoria = '';
            ctrl.obtenerCategorias();
          });          
        };

        ctrl.mostrarFormulario = (accion, libro) => {
          ctrl.libro = libro;
          ctrl.accionFormulario = accion;
          ctrl.errorFormulario = null;
        };

        ctrl.ocultarFormulario = () => {
          ctrl.limpiarLibro();
          ctrl.accionFormulario = null;
          ctrl.errorFormulario = null;
        };

        ctrl.confirmarFormulario = () => {
          if(!ctrl.libro) {
            return;
          }

          let operacion;

          switch(ctrl.accionFormulario.id) {
            case ctrl.acciones.crear.id: 
              ctrl.libro.id = 0;
              operacion = LibrosService.crear(ctrl.libro); break;

            case ctrl.acciones.modificar.id: 
              operacion = LibrosService.modificar(ctrl.libro.id, ctrl.libro); break;

            case ctrl.acciones.eliminar.id: 
              operacion = LibrosService.eliminar(ctrl.libro.id); break;
          }

          operacion.then(
            (resultado) =>  {
              ctrl.ocultarFormulario();
              onInit();
            },
            (error) =>  {
              ctrl.errorFormulario = error;
            }
          );
        };

        function onInit() {
          ctrl.limpiarLibro();
          ctrl.obtenerLibros();
          ctrl.obtenerCategorias();
        }

        onInit();
    }]);
})();