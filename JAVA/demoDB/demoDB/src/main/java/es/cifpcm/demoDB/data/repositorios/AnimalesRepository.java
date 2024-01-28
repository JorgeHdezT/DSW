package es.cifpcm.demoDB.data.repositorios;

import es.cifpcm.demoDB.model.Animal;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface AnimalesRepository extends JpaRepository<Animal, Integer>, JpaSpecificationExecutor<Animal> {

}