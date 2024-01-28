package es.cifpcm.demoDB.data.servicios;

import es.cifpcm.demoDB.data.repositorios.AnimalesRepository;
import es.cifpcm.demoDB.model.*;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.stereotype.Service;

import java.util.NoSuchElementException;

@Service
public class AnimalService {

    @Autowired
    private AnimalesRepository animalesRepository;

    public Integer save(Animal vO) {
        Animal bean = new Animal();
        BeanUtils.copyProperties(vO, bean);
        bean = animalesRepository.save(bean);
        return bean.getId();
    }

    public void delete(Integer id) {
        animalesRepository.deleteById(id);
    }

    public void update(Integer id, Animal vO) {
        Animal bean = requireOne(id);
        BeanUtils.copyProperties(vO, bean);
        animalesRepository.save(bean);
    }

    public Animal getById(Integer id) {
        Animal original = requireOne(id);
        return toDTO(original);
    }

    public Page<Animal> query(Animal vO) {
        throw new UnsupportedOperationException();
    }

    private Animal toDTO(Animal original) {
        Animal bean = new Animal();
        BeanUtils.copyProperties(original, bean);
        return bean;
    }

    private Animal requireOne(Integer id) {
        return animalesRepository.findById(id)
                .orElseThrow(() -> new NoSuchElementException("Resource not found: " + id));
    }
}
